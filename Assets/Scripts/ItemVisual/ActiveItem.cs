using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveItem:MonoBehaviour,IPointerClickHandler
{
    private Item _item;
    [SerializeField]
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    [SerializeField]
    private Image _bgColor;



    public void AssignItem(Item item)
    {
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        this._itemIcon = item.GetIcon();
        switch (item.GetRarity())
        {
            case 0:
                _bgColor.color = StylisticClass.CommonItem;
                break;
            case 1:
                _bgColor.color = StylisticClass.RareItem;
                break;
            case 2:
                _bgColor.color = StylisticClass.LegendaryItem;
                break;
            case 3:
                _bgColor.color = StylisticClass.BossItem;
                break;
        }
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked active item");
        _item.Activate();
    }

}
