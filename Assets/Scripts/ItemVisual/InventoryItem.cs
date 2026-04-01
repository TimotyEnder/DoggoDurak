using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    private Image _bgImage;
    [SerializeField]
    private TextMeshProUGUI _stackText;
    [SerializeField]
    private Animator _thisAnim;
    
    void Update()
    {
        
    }
    public void AssignItem(Item item) 
    {
        item.AssignInventoryItem(this);
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        this._itemIcon = item.GetIcon();
        _bgImage = this.transform.Find("InventoryItemBG").GetComponent<Image>();
        switch (item.GetRarity()) 
        {
            case 0:
                _bgImage.color = StylisticClass.CommonItem;
                break;
            case 1:
                _bgImage.color = StylisticClass.RareItem;
                break;
            case 2:
                _bgImage.color = StylisticClass.LegendaryItem;
                break;
            case 3:
                _bgImage.color = StylisticClass.BossItem;
                break;
        }
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }
    public void SetStackNum(List<Item> stacks) 
    {
        foreach(Item i in stacks)
        {
            i.AssignInventoryItem(this);
        }
        _stackText.gameObject.SetActive(true);
        _stackText.text = stacks.Count.ToString();
    }
    public void Bling()
    {
        _thisAnim.SetTrigger("Bling");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _thisAnim.SetTrigger("Hover");
    }
}
