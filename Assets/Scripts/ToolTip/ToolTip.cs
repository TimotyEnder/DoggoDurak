/*using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using static UnityEditor.Progress;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = $"<size=6><align=center>Name</align></size>\n" +
                                  $"<size=3><align=left>description</align></size>";
    [SerializeField]
    private   GameObject _tooltipPrefab; // A prefab of a default tooptip assigned in inspector

    private GameObject _currentTooltip;
    [SerializeField]
    private float ttPaddingX;
    [SerializeField]
    private float ttPaddingY;
    [SerializeField]
    private Canvas canvas;
    private bool _enabled;

    public void Start()
    {
        _enabled = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       if(_enabled)
        { 
             // Create tooltip
            _currentTooltip = Instantiate(_tooltipPrefab,GameObject.FindGameObjectWithTag("Canvas").transform);
            RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
            RectTransform ttImageRect = _currentTooltip.transform.Find("ToolTipBackground").GetComponent<RectTransform>();
            RectTransform myRect = GetComponent<RectTransform>();
            ToolTipScaler ttScript= _currentTooltip.GetComponentInChildren<ToolTipScaler>();
        

            // Set text first (this may affect the tooltip's size)
            TextMeshProUGUI ttText = _currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
            ttText.text = _tooltipText;
            ttScript.ScaleImageToText();

            // Force update the layout to get proper size
            LayoutRebuilder.ForceRebuildLayoutImmediate(ttRect);

            // Calculate possible positions
            Vector3[] preferredPositions = new Vector3[]
            {
            // Above
            myRect.position + new Vector3(0, (ttRect.rect.height  + ttImageRect.rect.height + ttPaddingY), 0),
            // Below
            myRect.position + new Vector3(0, -(ttRect.rect.height + ttImageRect.rect.height + ttPaddingY), 0),
            // Right
            myRect.position + new Vector3((ttRect.rect.width + ttImageRect.rect.width + ttPaddingX), 0, 0),
            // Left
            myRect.position + new Vector3(-(ttRect.rect.width  + ttImageRect.rect.width + ttPaddingX), 0, 0),
            // Top-Left
            myRect.position + new Vector3(-(ttRect.rect.width + ttImageRect.rect.width + ttPaddingX), (ttRect.rect.height + ttImageRect.rect.height + ttPaddingY), 0),
             // Top-Right
            myRect.position + new Vector3((ttRect.rect.width + ttImageRect.rect.width + ttPaddingX), (ttRect.rect.height  + ttImageRect.rect.height + ttPaddingY), 0),
            // Botttom-Left
            myRect.position + new Vector3(-(ttRect.rect.width + ttImageRect.rect.width + ttPaddingX), -(ttRect.rect.height  + ttImageRect.rect.height + ttPaddingY), 0),
             // Bottom-Right
            myRect.position + new Vector3((ttRect.rect.width  + ttImageRect.rect.width + ttPaddingX), -(ttRect.rect.height  + ttImageRect.rect.height + ttPaddingY), 0)
            };

            // Try each position until we find one that fits
            foreach (var pos in preferredPositions)
            {
                ttRect.position = pos;
                if (WithinScreenBounds(ttRect))
                {
                    break;
                }
            }

            // Final fallback - center on screen if all else fails
            if (!WithinScreenBounds(ttRect))
            {
                ttRect.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_currentTooltip != null)
            Destroy(_currentTooltip);
    }
    public void SetToolTipText(string text) 
    {
        this._tooltipText = text;
    }
    private bool WithinScreenBounds(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        return corners.All(c =>
            c.x >= 0 && c.x <= Screen.width &&
            c.y >= 0 && c.y <= Screen.height
        );
    }
    public void SetTooltipActiveState(bool active) 
    {
        _enabled = active;
        if (!active && _currentTooltip != null) 
        {
           Destroy(_currentTooltip);
        }
    }
}*/
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Cysharp.Threading.Tasks;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = $"<size=6><align=center>Name</align></size>\n" +
                                  $"<size=3><align=left>description</align></size>";
    [SerializeField]
    private GameObject _tooltipPrefab;
    
    private GameObject _currentTooltip;
    [SerializeField]
    private float ttPaddingX = 10f;
    [SerializeField]
    private float ttPaddingY = 10f;
    [SerializeField]
    private float displayWaitSeconds=0.05f;
    [SerializeField]
    private Canvas canvas;
    private bool _enabled = true;
    private bool _shouldExist=true;

    public async void OnPointerEnter(PointerEventData eventData)
    {
        if (_enabled && _currentTooltip == null)
        {
            _shouldExist=true;
            //wait a bit for the card to appear
            await UniTask.Delay(System.TimeSpan.FromSeconds(displayWaitSeconds));
            // Create tooltip
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
        RectTransform myRect = GetComponent<RectTransform>();
        
        // Convert rect transforms to screen space
        Vector3[] myCorners = new Vector3[4];
        myRect.GetWorldCorners(myCorners);
        
        Vector3[] ttCorners = new Vector3[4];
        ttRect.GetWorldCorners(ttCorners);
        
        // Get the actual sizes in screen space
        float ttWidth = ttCorners[2].x - ttCorners[0].x;
        float ttHeight = ttCorners[1].y - ttCorners[0].y;
        float myWidth = myCorners[2].x - myCorners[0].x;
        float myHeight = myCorners[1].y - myCorners[0].y;

        // Get the center position of this UI element
        Vector3 myCenter = myRect.position;
        
        // Define positions with proper spacing - using the center as reference point
        Vector3[] preferredPositions = new Vector3[]
        {
            // Above - center aligned horizontally
            new Vector3(
                myCenter.x,
                myCorners[1].y + ttPaddingY + (ttHeight * ttRect.pivot.y),
                0
            ),
            // Below - center aligned horizontally
            new Vector3(
                myCenter.x,
                myCorners[0].y - ttPaddingY - (ttHeight * (1 - ttRect.pivot.y)),
                0
            ),
            // Right - center aligned vertically
            new Vector3(
                myCorners[2].x + ttPaddingX + (ttWidth * ttRect.pivot.x),
                myCenter.y,
                0
            ),
            // Left - center aligned vertically
            new Vector3(
                myCorners[0].x - ttPaddingX - (ttWidth * (1 - ttRect.pivot.x)),
                myCenter.y,
                0
            ),
            // Top-Right (aligned to top-right corner of element)
            new Vector3(
                myCorners[2].x + ttPaddingX + (ttWidth * ttRect.pivot.x),
                myCorners[1].y + ttPaddingY + (ttHeight * ttRect.pivot.y),
                0
            ),
            // Top-Left (aligned to top-left corner of element)
            new Vector3(
                myCorners[0].x - ttPaddingX - (ttWidth * (1 - ttRect.pivot.x)),
                myCorners[1].y + ttPaddingY + (ttHeight * ttRect.pivot.y),
                0
            ),
            // Bottom-Right (aligned to bottom-right corner of element)
            new Vector3(
                myCorners[2].x + ttPaddingX + (ttWidth * ttRect.pivot.x),
                myCorners[0].y - ttPaddingY - (ttHeight * (1 - ttRect.pivot.y)),
                0
            ),
            // Bottom-Left (aligned to bottom-left corner of element)
            new Vector3(
                myCorners[0].x - ttPaddingX - (ttWidth * (1 - ttRect.pivot.x)),
                myCorners[0].y - ttPaddingY - (ttHeight * (1 - ttRect.pivot.y)),
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
                foundPosition = true;
                break;
            }
        }

        // Final fallback - adjust to fit on screen
        if (!foundPosition)
        {
            AdjustToScreenBounds(ttRect);
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
        
        float ttWidth = corners[2].x - corners[0].x;
        float ttHeight = corners[1].y - corners[0].y;
        
        Vector3 currentPos = rectTransform.position;
        Vector3 adjustedPos = currentPos;
        
        // Adjust X position - keep the padding in mind
        if (corners[0].x < 0)
            adjustedPos.x += -corners[0].x + ttPaddingX;
        else if (corners[2].x > Screen.width)
            adjustedPos.x -= corners[2].x - Screen.width + ttPaddingX;
            
        // Adjust Y position - keep the padding in mind
        if (corners[0].y < 0)
            adjustedPos.y += -corners[0].y + ttPaddingY;
        else if (corners[1].y > Screen.height)
            adjustedPos.y -= corners[1].y - Screen.height + ttPaddingY;
            
        rectTransform.position = adjustedPos;
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
        }
    }
}