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
        GameObject rewObj = GameObject.Find("RewardItemGrid");
        if (rewObj != null)
        {
            _rewgrid = rewObj.GetComponent<RewardItemGrid>();
        }
    }
    public Item GetAssignedItem()
    {
        return _item;
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
        //_toolTip.infoRight="<size="+SettingsState.ToolTipFontSizeText+">"+Item.rarityIntToWord[item.GetRarity()]+" Item"+"</size>";
    }
    private void OnClickActiveItem()
    {
        if (price==0 || price>0 && GameHandler.Instance.GetGameState()._rubles>=price) 
        {
            GameHandler.Instance.GetGameState().AddItem(this._item);
            GetComponent<ToolTip>().SetTooltipActiveState(false);
            if (price==0 && _rewgrid != null) 
            {
                 _rewgrid.ChoiceHappened(); 
            }
            if(price>0) 
            { 
                GameHandler.Instance.GetGameState()._rubles-=price; 
                GameObject.Find("RubleText").GetComponent<RubleText>().UpdateRubleAmount();
            } 
            Destroy(this.gameObject);
        }
    }
}
