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
        UpdateGridSpacing();
    }
    
    [ContextMenu("Update Spacing")]
    public void UpdateGridSpacing()
    {
        if (gridLayout == null || rectTransform == null) return;
        
        int childCount = transform.childCount;
        if (childCount == 0) return;
        
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
        
        int rowCount = Mathf.CeilToInt((float)childCount / constraintCount);
        
        float availableWidth = rectTransform.rect.width 
            - gridLayout.padding.left 
            - gridLayout.padding.right;
        
        float totalCellWidth = gridLayout.cellSize.x * constraintCount;
        
        float requiredSpacing = (availableWidth - totalCellWidth) / (constraintCount - 1);
        
        requiredSpacing = Mathf.Clamp(requiredSpacing, minSpacing, maxSpacing);
        
        gridLayout.spacing = new Vector2(requiredSpacing, gridLayout.spacing.y);
        
        if (rowCount > 1)
        {
            float availableHeight = rectTransform.rect.height 
                - gridLayout.padding.top 
                - gridLayout.padding.bottom;
            
            float totalCellHeight = gridLayout.cellSize.y * rowCount;
            float requiredVerticalSpacing = (availableHeight - totalCellHeight) / (rowCount - 1);
            
            requiredVerticalSpacing = Mathf.Clamp(requiredVerticalSpacing, minSpacing, maxSpacing);
            gridLayout.spacing = new Vector2(gridLayout.spacing.x, requiredVerticalSpacing);
        }
    }
    
    private void ConfigureFixedRows(int childCount)
    {
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        gridLayout.constraintCount = constraintCount;
        
        int columnsPerRow = Mathf.CeilToInt((float)childCount / constraintCount);
        
        float availableWidth = rectTransform.rect.width 
            - gridLayout.padding.left 
            - gridLayout.padding.right;
        
        float totalCellWidth = gridLayout.cellSize.x * columnsPerRow;
        float requiredSpacing = (availableWidth - totalCellWidth) / (columnsPerRow - 1);
        
        requiredSpacing = Mathf.Clamp(requiredSpacing, minSpacing, maxSpacing);
        
        gridLayout.spacing = new Vector2(requiredSpacing, gridLayout.spacing.y);
    }
    
    public void RefreshLayout() //incase the grid changes dynamically
    {
        UpdateGridSpacing();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}