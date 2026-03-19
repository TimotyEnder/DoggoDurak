using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour,IPointerEnterHandler
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgColor;
    private Button _button;
    private RewardItemGrid _rewgrid;
    [SerializeField]
    private TextMeshProUGUI _priceText;
    [SerializeField]
    private GameObject _costImage;
    private int price = 0;
    private Animator _thisAnim;

    private void Start()
    {
        _thisAnim=GetComponent<Animator>();
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
            _costImage.SetActive(true);
            _priceText.text = itemPrice.ToString()+_priceText.text[_priceText.text.Length-1];   
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        _thisAnim.SetTrigger("Hover");
    }
    private void OnClickActiveItem()
    {
        if (price==0 || price>0 && GameHandler.Instance.GetGameState()._rubles>=price && _rewgrid.GetRemainingChoices()>0) 
        {
            GameHandler.Instance.GetGameState().AddItem(this._item);
            _thisAnim.SetTrigger("Pick");
            GetComponent<ToolTip>().SetTooltipActiveState(false);
            if (price==0 && _rewgrid != null && !_item.IsConsumable()) 
            {
                 _rewgrid.ChoiceHappened(); 
            }
            if(price>0) 
            { 
                GameHandler.Instance.UpdateMoney(-price);
            } 
            Destroy(this.gameObject,0.5f);
        }
    }
}
