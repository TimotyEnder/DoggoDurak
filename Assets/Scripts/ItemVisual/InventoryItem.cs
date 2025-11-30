using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgImage;
    [SerializeField]
    private TextMeshProUGUI _stackText;
    
    void Update()
    {
        
    }
    public void AssignItem(Item item) 
    {
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        this._itemIcon = item.GetIcon();
        _bgImage = this.transform.Find("InventoryItemBG").GetComponent<Image>();
        switch (item.GetRarity()) 
        {
            case 0:
                _bgImage.color = ColorScheme.CommonItemGreen;
                break;
            case 1:
                _bgImage.color = ColorScheme.RareItemBlue;
                break;
            case 2:
                _bgImage.color = ColorScheme.LegendaryItemGold;
                break;
            case 3:
                _bgImage.color = ColorScheme.BossItemRed;
                break;
        }
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }
    public void SetStackNum(int stacks) 
    {
        _stackText.gameObject.SetActive(true);
        _stackText.text = stacks.ToString();
    }
}
