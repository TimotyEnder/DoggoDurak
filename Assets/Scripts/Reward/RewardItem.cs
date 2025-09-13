using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgColor;
    private Button _button;
    private RewardItemGrid _rewgrid;
    [SerializeField]
    private TextMeshProUGUI _priceText;
    private int price = 0;

    private void Start()
    {
        _button = transform.Find("Button").GetComponent<Button>();
        _button.onClick.AddListener(OnClickActiveItem);
        _rewgrid= GameObject.Find("RewardItemGrid").GetComponent<RewardItemGrid>();
    }

    public void AssignItem(Item item, int itemPrice=0)
    {
        if (itemPrice > 0) 
        {
            this.price = itemPrice;
            _priceText.gameObject.SetActive(true);
            _priceText.text = itemPrice.ToString();   
        }
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
        if (price==0 || price>0 && GameHandler.Instance.GetGameState()._rubles>price) 
        {
            GameHandler.Instance.GetGameState().AddItem(this._item);
            GetComponent<ToolTip>().SetTooltipActiveState(false);
            if (price==0 && _rewgrid != null) { _rewgrid.ChoiceHappened(); }
            if(price>0) { GameHandler.Instance.GetGameState()._rubles-=price; } 
            Destroy(this.gameObject);
        }
    }
}
