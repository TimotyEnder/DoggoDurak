using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Cysharp.Threading.Tasks;
using System;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = $"<size=6><align=center>Name</align></size>\n" +
                                  $"<size=3><align=left>description</align></size>";
    [SerializeField]
    private GameObject _tooltipPrefab;
    
    private GameObject _currentTooltip;
    [SerializeField]
    private float ttPaddingX;
    [SerializeField]
    private float ttPaddingY;
    [SerializeField]
    private float displayWaitSeconds=0.05f;
    [SerializeField]
    private Canvas canvas;
    private bool _enabled = true;
    private bool _shouldExist=true;

    public void changePadding(int x, int y)
    {
        ttPaddingY=y;
        ttPaddingX=x;
    }
    
    public async void OnPointerEnter(PointerEventData eventData)
    {
        if (_enabled && _currentTooltip == null)
        {
            _shouldExist=true;
            //wait a bit for the card to appear
            await UniTask.Delay(System.TimeSpan.FromSeconds(displayWaitSeconds));
            // Create tooltip
            _currentTooltip = Instantiate(_tooltipPrefab,this.transform.position,Quaternion.identity,this.transform);
            if(!_shouldExist)
            {
                 Destroy(_currentTooltip);
                 _currentTooltip = null;
            }
            else
            {
                // Set text first
                TextMeshProUGUI ttText = _currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
                ttText.text = _tooltipText;
                
                // Scale the background to fit text
                ToolTipScaler ttScript = _currentTooltip.GetComponentInChildren<ToolTipScaler>();
                if (ttScript != null)
                {
                    ttScript.ScaleImageToText();
                }
                
                // Force layout rebuild to get proper sizes
                Canvas.ForceUpdateCanvases();
                LayoutRebuilder.ForceRebuildLayoutImmediate(_currentTooltip.GetComponent<RectTransform>());
                
                // Position the tooltip
                PositionTooltip();
            }
        }
    }

    private void PositionTooltip()
    {
        if (_currentTooltip == null) return;

        RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
        RectTransform myRect= this.gameObject.GetComponent<RectTransform>();
        
        // Define positions in canvas local space by aligning edges
        Vector2[] preferredPositions = new Vector2[]
        {
            // Above - align bottom-left of tooltip to top-left of card
            new Vector2(
                0,  // card top-left x
                (ttRect.rect.height/2)+ (myRect.rect.height/2)// above card top edge
            ),
            // Below - align top-left of tooltip to bottom-left of card  
            new Vector2(
                0,  // card top-left x
                -((ttRect.rect.height/2)+(myRect.rect.height/2))// above card top edge
            ),
            // Right - align bottom-left of tooltip to bottom-right of card
            new Vector2(
                (ttRect.rect.width/2)+ (myRect.rect.width/2),  // right of card right edge
                0  // card top-right y
            ),
            // Left - align bottom-right of tooltip to bottom-left of card
            new Vector2(
                -((ttRect.rect.height/2)+(myRect.rect.height/2)),  // left of card left edge
                0 // card bottom-left y
            )
        };

        // Try each position
        bool foundPosition = false;
        foreach (var pos in preferredPositions)
        {
            ttRect.localPosition = new Vector3(pos.x, pos.y, 0);
            if (IsFullyWithinScreenBounds(ttRect))
            {
                foundPosition = true;
                break;
            }
        }
    }

    private bool IsFullyWithinScreenBounds(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float safeMargin = 1f; // 1 pixel margin to avoid right/bottom edge issues
        return corners.All(c =>
            c.x >= 0 && c.x <= Screen.width - safeMargin &&
            c.y >= 0 && c.y <= Screen.height - safeMargin
        );
    }

    private void AdjustToScreenBounds(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        
        // Get the canvas
        Canvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        
        // Convert corners to canvas local space for adjustment
        Vector2[] localCorners = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, corners[i], null, out localCorners[i]);
        }
        
        float ttWidth = Mathf.Abs(localCorners[2].x - localCorners[0].x);
        float ttHeight = Mathf.Abs(localCorners[1].y - localCorners[0].y);
        
        Vector3 currentLocalPos = rectTransform.localPosition;
        Vector3 adjustedLocalPos = currentLocalPos;
        
        // Get canvas bounds in local space
        Vector3[] canvasCorners = new Vector3[4];
        canvasRect.GetLocalCorners(canvasCorners);
        
        // Adjust X position in local space
        if (localCorners[0].x < canvasCorners[0].x)
            adjustedLocalPos.x += canvasCorners[0].x - localCorners[0].x + ttPaddingX;
        else if (localCorners[2].x > canvasCorners[2].x)
            adjustedLocalPos.x -= localCorners[2].x - canvasCorners[2].x + ttPaddingX;
            
        // Adjust Y position in local space
        if (localCorners[0].y < canvasCorners[0].y)
            adjustedLocalPos.y += canvasCorners[0].y - localCorners[0].y + ttPaddingY;
        else if (localCorners[1].y > canvasCorners[1].y)
            adjustedLocalPos.y -= localCorners[1].y - canvasCorners[1].y + ttPaddingY;
            
        rectTransform.localPosition = adjustedLocalPos;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shouldExist=false;
        if (_currentTooltip != null)
        {
            Destroy(_currentTooltip);
            _currentTooltip = null;
            GameObject[] zombieToolTips= GameObject.FindGameObjectsWithTag("ToolTip"); //if in anyway any tooltips somehow were not destroyed, destroy them
            foreach(GameObject zombie in  zombieToolTips)
            {
                Destroy(zombie);
            }
        }
    }

    public void SetToolTipText(string text) 
    {
        this._tooltipText = text;
    }

    public void SetTooltipActiveState(bool active) 
    {
        _enabled = active;
        if (!active && _currentTooltip != null) 
        {
            Destroy(_currentTooltip);
            _currentTooltip = null;
            GameObject[] zombieToolTips= GameObject.FindGameObjectsWithTag("ToolTip"); //if in anyway any tooltips somehow were not destroyed, destroy them
            foreach(GameObject zombie in  zombieToolTips)
            {
                Destroy(zombie);
            }
        }
    }
}