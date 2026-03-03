using UnityEngine;
using UnityEngine.UI;

public class RulesContent : MonoBehaviour
{
    private GridLayoutGroup _thisGrid;
    private RectTransform _thisRect;
    private float _initialCellSize;

    void Awake()
    {
        _thisGrid= this.GetComponent<GridLayoutGroup>();
        _thisRect= this.GetComponent<RectTransform>();
        this._initialCellSize=_thisGrid.cellSize.x;
    }
    private void OnTransformChildrenChanged()
    {
        _thisGrid.cellSize = new Vector2(_thisGrid.cellSize.x, _initialCellSize);

        if(_thisGrid.cellSize.y*this.transform.childCount>_thisRect.rect.height)
        {
            _thisGrid.cellSize = new Vector2(_thisGrid.cellSize.x, _thisRect.rect.height/this.transform.childCount);
        }
    }
}
