using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class RulesContent : MonoBehaviour
{
    private GridLayoutGroup _thisGrid;
    private RectTransform _thisRect;

    void Awake()
    {
        _thisGrid= this.GetComponent<GridLayoutGroup>();
        _thisRect= this.GetComponent<RectTransform>();
    }
    private void OransformChildrenChanged()
    {
        if(_thisGrid.cellSize.y*this.transform.childCount>_thisRect.rect.width)
        {
            _thisGrid.cellSize = new Vector2(_thisGrid.cellSize.x, _thisRect.rect.width/this.transform.childCount);
        }
    }
}
