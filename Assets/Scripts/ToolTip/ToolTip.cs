using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = "Test";
    public  GameObject _tooltipPrefab; // A prefab of a default tooptip assigned in inspector

    private GameObject _currentTooltip;

    private float ttPadding = 5;

    private Canvas canvas;

    public void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Create tooltip
        _currentTooltip = Instantiate(_tooltipPrefab, transform.parent); // Or another appropriate parent

        // Position it (example - above the element)
        RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
        RectTransform myRect = GetComponent<RectTransform>();

        ttRect.position = myRect.position + new Vector3(0, (ttRect.rect.height*ttRect.localScale.x+(myRect.rect.height)+10), 0);//simple but we have to multiply but scale as preferred size is set by the backgorund itself (+4 just to have a small amount of pixels in between to not cause probelms on pointer exit)
        //if tooltip offscfeen show it in the bottom

        Vector3[] corners = new Vector3[4];
        ttRect.GetWorldCorners(corners);
        Vector3 min = canvas.worldCamera.WorldToViewportPoint(corners[0]);
        Vector3 max = canvas.worldCamera.WorldToViewportPoint(corners[2]);

        if (!(max.x < 0 || min.x > 1 || max.y < 0 || min.y > 1))
        {
            ttRect.position = myRect.position + new Vector3(0, -(ttRect.rect.height * ttRect.localScale.x + (myRect.rect.height) + 10), 0);
        }
        // Set text
        TextMeshProUGUI ttText = _currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
        ttText.text = _tooltipText;
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
}
