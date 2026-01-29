using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CompressibleGrid : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private ConstraintType constraintType = ConstraintType.FixedColumnCount;
    [SerializeField] private int constraintCount = 5; // Fixed columns or rows
    
    [Header("Spacing Limits")]
    [SerializeField] private float maxSpacing = 0f; // Your "normal" spacing
    [SerializeField] private float minSpacing = -20f; // How much negative spacing is allowed
    
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;
    
    public enum ConstraintType
    {
        FixedColumnCount,
        FixedRowCount
    }
    
    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        UpdateGridSpacing();
    }
    
    void Update()
    {
        // Update only when needed (when children change or layout changes)
        // You might want to optimize this based on your specific needs
        UpdateGridSpacing();
    }
    
    [ContextMenu("Update Spacing")]
    public void UpdateGridSpacing()
    {
        if (gridLayout == null || rectTransform == null) return;
        
        int childCount = transform.childCount;
        if (childCount == 0) return;
        
        // Set constraint based on selection
        switch (constraintType)
        {
            case ConstraintType.FixedColumnCount:
                ConfigureFixedColumns(childCount);
                break;
            case ConstraintType.FixedRowCount:
                ConfigureFixedRows(childCount);
                break;
        }
    }
    
    private void ConfigureFixedColumns(int childCount)
    {
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = constraintCount;
        
        // Calculate how many rows we'll have
        int rowCount = Mathf.CeilToInt((float)childCount / constraintCount);
        
        // Calculate available width (minus padding)
        float availableWidth = rectTransform.rect.width 
            - gridLayout.padding.left 
            - gridLayout.padding.right;
        
        // Calculate how much space all cells would take without spacing
        float totalCellWidth = gridLayout.cellSize.x * constraintCount;
        
        // Calculate required spacing to fit everything
        float requiredSpacing = (availableWidth - totalCellWidth) / (constraintCount - 1);
        
        // Clamp the spacing between min and max
        requiredSpacing = Mathf.Clamp(requiredSpacing, minSpacing, maxSpacing);
        
        // Apply the spacing
        gridLayout.spacing = new Vector2(requiredSpacing, gridLayout.spacing.y);
        
        // Also adjust vertical spacing if we have multiple rows
        if (rowCount > 1)
        {
            float availableHeight = rectTransform.rect.height 
                - gridLayout.padding.top 
                - gridLayout.padding.bottom;
            
            float totalCellHeight = gridLayout.cellSize.y * rowCount;
            float requiredVerticalSpacing = (availableHeight - totalCellHeight) / (rowCount - 1);
            
            // Keep vertical spacing at maxSpacing or adjust if you want
            requiredVerticalSpacing = Mathf.Clamp(requiredVerticalSpacing, minSpacing, maxSpacing);
            gridLayout.spacing = new Vector2(gridLayout.spacing.x, requiredVerticalSpacing);
        }
    }
    
    private void ConfigureFixedRows(int childCount)
    {
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        gridLayout.constraintCount = constraintCount;
        
        // Calculate how many columns we'll have per row
        int columnsPerRow = Mathf.CeilToInt((float)childCount / constraintCount);
        
        // Calculate available width
        float availableWidth = rectTransform.rect.width 
            - gridLayout.padding.left 
            - gridLayout.padding.right;
        
        // Calculate required horizontal spacing
        float totalCellWidth = gridLayout.cellSize.x * columnsPerRow;
        float requiredSpacing = (availableWidth - totalCellWidth) / (columnsPerRow - 1);
        
        // Clamp the spacing
        requiredSpacing = Mathf.Clamp(requiredSpacing, minSpacing, maxSpacing);
        
        // Apply spacing
        gridLayout.spacing = new Vector2(requiredSpacing, gridLayout.spacing.y);
    }
    
    // Call this when you manually add/remove children
    public void RefreshLayout()
    {
        UpdateGridSpacing();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}