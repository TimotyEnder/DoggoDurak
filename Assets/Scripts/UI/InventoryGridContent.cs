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
            float lo = 0f;
            float hi = Mathf.Min(
                (_thisRect.rect.width  - _thisGrid.padding.left - _thisGrid.padding.right + _thisGrid.spacing.x) - _thisGrid.spacing.x,
                (_thisRect.rect.height - _thisGrid.padding.top  - _thisGrid.padding.bottom + _thisGrid.spacing.y) - _thisGrid.spacing.y
            );

            for (int i = 0; i < 64; i++) // 64 iterations gives float precision
            {
                float mid = (lo + hi) / 2f;
                int cols = (int)Mathf.Floor((_thisRect.rect.width - _thisGrid.padding.left - _thisGrid.padding.right + _thisGrid.spacing.x) / (mid + _thisGrid.spacing.x));
                int rows = (int)Mathf.Ceil((float)_thisRect.childCount / cols);
                float usedH = _thisGrid.padding.top + _thisGrid.padding.bottom + (rows * mid) + ((rows - 1) * _thisGrid.spacing.y);

                if (usedH <= _thisRect.rect.height)
                    lo = mid;
                else
                    hi = mid;
            }

            _thisGrid.cellSize = new Vector2(lo, lo);
        }
    }
}
