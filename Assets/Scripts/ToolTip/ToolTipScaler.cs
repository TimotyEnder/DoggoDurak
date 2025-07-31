using UnityEngine;
using TMPro;
using UnityEngine.UI;
[ExecuteAlways]
public class ToolTipScaler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private Vector2 padding = new Vector2(20, 10);

    private RectTransform imageRectTransform;
    private RectTransform textRectTransform;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        imageRectTransform = GetComponent<RectTransform>();

        if (targetText != null)
        {
            textRectTransform = targetText.GetComponent<RectTransform>();
        }
    }

    public void ScaleImageToText()
    {
        textRectTransform.sizeDelta = new Vector2(textRectTransform.sizeDelta.x, targetText.GetPreferredValues().y); 
        if (targetText == null || textRectTransform == null) return;

        // Get the rendered dimensions of the text
        Vector2 textSize = new Vector2(textRectTransform.sizeDelta.x, targetText.GetPreferredValues().y);

        // Apply padding
        textSize += padding;

        // Update the image size
        imageRectTransform.sizeDelta = textSize;

        // Match position
        imageRectTransform.position = textRectTransform.position;
    }
}
