using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class STController : MonoBehaviour
{
    public enum TextAlign { Left, Right }

    private Image panel;
    private TextMeshProUGUI left;
    private TextMeshProUGUI right;
    private RectTransform rect;
    private Canvas canvas;
    private RectTransform canvasRect;
    private Camera uiCamera;

    private bool visible;
    private Vector2 vel;
    private Vector2 targetPos;
    private Vector2 lastPreferred;
    private LayoutElement layout;

    [Header("Layout")]
    public float maxWidth = 520f;
    public float minWidth = 120f;
    public Vector2 padding = new Vector2(24f, 16f);
    public float margin = 8f;

    [Header("Follow")]
    public Vector2 offset = new Vector2(18f, -18f);
    [Range(0f, 0.2f)] public float smooth = 0.06f;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        panel = GetComponent<Image>();
        layout = GetComponent<LayoutElement>();

        // Find the left/right TMP children
        var tmps = GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (var t in tmps)
        {
            if (t.name == "_left") left = t;
            else if (t.name == "_right") right = t;
        }

        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.transform as RectTransform;
        uiCamera = canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null;

        HideTooltip();
    }

    private void LateUpdate()
    {
        if (!visible) return;

        Vector2 pref = Measure();
        Apply(pref);

        UpdatePivot();
        Vector2 mouseLocal = ScreenToCanvas(Input.mousePosition);
        targetPos = Clamp(mouseLocal + offset, pref);

        rect.anchoredPosition = Vector2.SmoothDamp(
            rect.anchoredPosition, targetPos, ref vel, smooth);
    }

    // --- Text API used by SimpleTooltip.cs ---

    public void SetCustomStyledText(string text, SimpleTooltipStyle style, TextAlign align)
    {
        ApplyStyle(style);

        if (align == TextAlign.Left) left.text = text;
        else right.text = text;

        lastPreferred = Vector2.zero;
    }

    public void SetRawText(string text, TextAlign align)
    {
        if (align == TextAlign.Left) left.text = text;
        else right.text = text;

        lastPreferred = Vector2.zero;
    }

    public void ShowTooltip()
    {
        visible = true;
        rect.gameObject.SetActive(true);
        rect.anchoredPosition = ScreenToCanvas(Input.mousePosition) + offset;
    }

    public void HideTooltip()
    {
        visible = false;
        rect.gameObject.SetActive(false);
        vel = Vector2.zero;
    }

    // --- Helpers ---

    private void ApplyStyle(SimpleTooltipStyle style)
    {
        panel.sprite = style.slicedSprite;
        panel.color = style.color;

        left.font = style.fontAsset;
        left.color = style.defaultColor;
        right.font = style.fontAsset;
        right.color = style.defaultColor;
    }

    private Vector2 Measure()
    {
        if (lastPreferred != Vector2.zero) return lastPreferred;

        float contentMax = maxWidth - padding.x;

        Vector2 l = left.GetPreferredValues(left.text, contentMax, 0);
        Vector2 r = right.GetPreferredValues(right.text, contentMax, 0);

        float w = Mathf.Clamp(Mathf.Max(l.x, r.x) + padding.x, minWidth, maxWidth);
        float h = Mathf.Max(l.y, r.y) + padding.y;

        return lastPreferred = new Vector2(w, h);
    }

    private void Apply(Vector2 pref)
    {
        if (layout)
        {
            layout.preferredWidth = pref.x;
            layout.preferredHeight = pref.y;
        }
        else
        {
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pref.x);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pref.y);
        }
    }

    private void UpdatePivot()
    {
        Vector2 mouse = ScreenToCanvas(Input.mousePosition);
        Vector2 center = canvasRect.rect.center;

        float px = mouse.x < center.x ? 0f : 1f;
        float py = mouse.y < center.y ? 0f : 1f;

        rect.pivot = new Vector2(px, py);
    }

   private Vector2 ScreenToCanvas(Vector2 screenPos)
    {
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, screenPos, uiCamera, out local);

        return local;
    }



    private Vector2 Clamp(Vector2 pos, Vector2 size)
    {
        Vector2 min = canvasRect.rect.min + new Vector2(margin, margin);
        Vector2 max = canvasRect.rect.max - new Vector2(margin, margin);

        Vector2 bl = pos - Vector2.Scale(size, rect.pivot);
        Vector2 tr = bl + size;

        Vector2 delta = Vector2.zero;
        if (bl.x < min.x) delta.x = min.x - bl.x;
        if (bl.y < min.y) delta.y = min.y - bl.y;
        if (tr.x > max.x) delta.x = max.x - tr.x;
        if (tr.y > max.y) delta.y = max.y - tr.y;

        return pos + delta;
    }
}
