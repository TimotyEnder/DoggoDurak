using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using static UnityEditor.Progress;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = $"<size=6><align=center>Name</align></size>\n" +
                                  $"<size=3><align=left>description</align></size>";
    [SerializeField]
    private   GameObject _tooltipPrefab; // A prefab of a default tooptip assigned in inspector

    private GameObject _currentTooltip;

    private float ttPadding = 5;
    [SerializeField]
    private Canvas canvas;

    public void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Create tooltip
        _currentTooltip = Instantiate(_tooltipPrefab, transform.parent);
        RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
        RectTransform myRect = GetComponent<RectTransform>();

        // Set text first (this may affect the tooltip's size)
        TextMeshProUGUI ttText = _currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
        ttText.text = _tooltipText;

        // Force update the layout to get proper size
        LayoutRebuilder.ForceRebuildLayoutImmediate(ttRect);

        // Calculate possible positions
        Vector3[] preferredPositions = new Vector3[]
        {
        // Above
        myRect.position + new Vector3(0, (ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0),
        // Below
        myRect.position + new Vector3(0, -(ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0),
        // Right
        myRect.position + new Vector3((ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), 0, 0),
        // Left
        myRect.position + new Vector3(-(ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), 0, 0),
        // Top-Left
        myRect.position + new Vector3(-(ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), (ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0),
         // Top-Right
        myRect.position + new Vector3((ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), (ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0),
        // Botttom-Left
        myRect.position + new Vector3(-(ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), -(ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0),
         // Bottom-Right
        myRect.position + new Vector3((ttRect.rect.width * ttRect.localScale.x + myRect.rect.width + 20), -(ttRect.rect.height * ttRect.localScale.y + myRect.rect.height + 20), 0)
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
}
