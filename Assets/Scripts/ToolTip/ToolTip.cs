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
    private float ttPaddingX;
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
            ttPaddingY=Screen.height*0.02f;
            _currentTooltip = Instantiate(_tooltipPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            if(!_shouldExist)
            {
                 Destroy(_currentTooltip);
                 _currentTooltip = null;
            }
            
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

    private void PositionTooltip()
{
    if (_currentTooltip == null) return;

    RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
    RectTransform ttBgRect= _currentTooltip.transform.Find("ToolTipBackground").GetComponent<RectTransform>();
    RectTransform myRect = GetComponent<RectTransform>();
    
    // Use RectTransform.rect for reliable size calculations
    float ttWidth = ttBgRect.rect.width;
    float ttHeight = ttBgRect.rect.height;
    float myWidth = myRect.rect.width;
    float myHeight = myRect.rect.height;

    // Convert to screen space if needed, or use local positions
    Vector3 myCenter = myRect.position;
    
    // Define positions relative to the tooltip's pivot (usually center)
    Vector3[] preferredPositions = new Vector3[]
    {
        // Above - center aligned horizontally
        new Vector3(
            myCenter.x,
            myCenter.y + (myHeight/2) + (ttHeight/2) + ttPaddingY,
            0
        ),
        // Below - center aligned horizontally
        new Vector3(
            myCenter.x,
            myCenter.y - (myHeight/2) - (ttHeight/2) - ttPaddingY,
            0
        ),
        // Right - center aligned vertically
        new Vector3(
            myCenter.x + (myWidth/2) + (ttWidth/2) + ttPaddingX,
            myCenter.y,
            0
        ),
        // Left - center aligned vertically
        new Vector3(
            myCenter.x - (myWidth/2) - (ttWidth/2) - ttPaddingX,
            myCenter.y,
            0
        ),
        // Top Left - center aligned vertically
        new Vector3(
            myCenter.x - (myWidth/2) - (ttWidth/2) - ttPaddingX,
            myCenter.y + (myHeight/2) + (ttHeight/2) + ttPaddingY,
            0
        ),
        // Top Right - center aligned vertically
        new Vector3(
            myCenter.x + (myWidth/2) + (ttWidth/2) + ttPaddingX,
            myCenter.y + (myHeight/2) + (ttHeight/2) + ttPaddingY,
            0
        ),
        // Bottom Left - center aligned vertically
        new Vector3(
            myCenter.x - (myWidth/2) - (ttWidth/2) - ttPaddingX,
            myCenter.y - (myHeight/2) - (ttHeight/2) - ttPaddingY,
            0
        ),
        // Bottom Right - center aligned vertically
        new Vector3(
            myCenter.x + (myWidth/2) + (ttWidth/2) + ttPaddingX,
            myCenter.y - (myHeight/2) - (ttHeight/2) - ttPaddingY,
            0
        )
    };

    // Try each position until we find one that fits
    bool foundPosition = false;
    foreach (var pos in preferredPositions)
    {
        ttRect.position = pos;
        if (IsFullyWithinScreenBounds(ttRect))
        {
            Debug.Log(pos+"Is fully withing screen bounds");
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