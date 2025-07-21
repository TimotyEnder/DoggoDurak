using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgColor;
    private Button _button;

    private void Start()
    {
        _button = transform.Find("Button").GetComponent<Button>();
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
                _bgColor.color = ColorScheme.CommonItemGreen;
                break;
            case 1:
                _bgColor.color = ColorScheme.RareItemBlue;
                break;
            case 2:
                _bgColor.color = ColorScheme.LegendaryItemGold;
                break;
            case 3:
                _bgColor.color = ColorScheme.BossItemRed;
                break;
        }
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }
    private void OnClickActiveItem()
    {
        GameHandler.Instance.GetGameState().AddItem(this._item);
        Destroy(this.gameObject);
    }
}
