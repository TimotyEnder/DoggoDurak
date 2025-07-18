using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Item _item;
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    
    void Start()
    {
        _toolTip= GetComponent<ToolTip>();
    }
    void Update()
    {
        
    }
    public void AssignItem(Item item) 
    {
        this._item = item;
        this._itemIcon = item.GetIcon();
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }
}
