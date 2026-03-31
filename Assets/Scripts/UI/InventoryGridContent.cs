using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGridContent : MonoBehaviour
{
    private GridLayoutGroup _thisGrid;
    private RectTransform _thisRect;
    private float _initialCellSizeY;
    private float _initialCellSizeX;

    void Awake()
    {
        _thisGrid= this.GetComponent<GridLayoutGroup>();
        _thisRect= this.GetComponent<RectTransform>();
        this._initialCellSizeY=_thisGrid.cellSize.y;
        this._initialCellSizeX=_thisGrid.cellSize.x;

    }
   private void OnTransformChildrenChanged()
    {
        _thisGrid.cellSize = new Vector2(_initialCellSizeX, _initialCellSizeY);
        float cellsPerRow = Mathf.Floor((_thisRect.rect.width - _thisGrid.padding.left - _thisGrid.padding.right + _thisGrid.spacing.x) / (_thisGrid.cellSize.x + _thisGrid.spacing.x));
        int rowsNeeded = (int)Mathf.Ceil(_thisRect.childCount / cellsPerRow);
        if ((_thisGrid.padding.top + _thisGrid.padding.bottom + (rowsNeeded * _thisGrid.cellSize.y) + ((rowsNeeded - 1) * _thisGrid.spacing.y)) > _thisRect.rect.height)
        {
            // Try each plausible column count from 1 to N — O(N) but N is typically tiny
            float bestSize = 0f;
            for (int cols = 1; cols <= _thisRect.childCount; cols++)
            {
                int rows = (int)Mathf.Ceil((float)_thisRect.childCount / cols);
                float availW = (_thisRect.rect.width - _thisGrid.padding.left - _thisGrid.padding.right + _thisGrid.spacing.x) / cols - _thisGrid.spacing.x;
                float availH = (_thisRect.rect.height - _thisGrid.padding.top - _thisGrid.padding.bottom + _thisGrid.spacing.y) / rows - _thisGrid.spacing.y;
                float size = Mathf.Min(availW, availH);
                if (size > bestSize) bestSize = size;
            }
            _thisGrid.cellSize = new Vector2(bestSize, bestSize);
        }
    }
}
