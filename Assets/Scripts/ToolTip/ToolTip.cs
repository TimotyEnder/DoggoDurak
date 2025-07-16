using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _tooltipText = "Default ToolTip";
    public  GameObject _tooltipPrefab; // A prefab of a default tooptip assigned in inspector

    private GameObject _currentTooltip;

    private float ttPadding = 5;

    public void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Create tooltip
        _currentTooltip = Instantiate(_tooltipPrefab, transform.parent.parent); // Or another appropriate parent

        // Position it (example - above the element)
        RectTransform ttRect = _currentTooltip.GetComponent<RectTransform>();
        RectTransform myRect = GetComponent<RectTransform>();

        ttRect.position = myRect.position + new Vector3(myRect.rect.width, 0, 0);

        // Set text
        TextMeshProUGUI ttText = _currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
        Image bgImage= _currentTooltip.GetComponentInChildren<Image>();
        bgImage.rectTransform.sizeDelta = new Vector2(
        ttText.preferredWidth + ttPadding,
        ttText.preferredHeight + ttPadding);
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
