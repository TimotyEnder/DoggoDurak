using UnityEngine;
using UnityEngine.UI;

public class ActiveItem:MonoBehaviour
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgColor;
    private Button _button;

    private void Start()
    {
        _button=transform.Find("Button").GetComponent<Button>();
        _button.onClick.AddListener(OnClickActiveItem);
    }

    public void AssignItem(Item item)
    {
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        this._itemIcon = item.GetIcon();
        _bgColor = this.transform.Find("Button").GetComponent<Image>();
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
    private void OnClickActiveItem() 
    {
        _item.OnActivate();
    }
}
