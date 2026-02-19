using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveItem:MonoBehaviour,IPointerClickHandler,IPointerEnterHandler
{
    private Item _item;
    [SerializeField]
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    [SerializeField]
    private Image _bgColor;
    [SerializeField]
    private Animator _anim;



    public void AssignItem(Item item)
    {
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        SelectColor();
        this._itemIcon = item.GetIcon();
        _toolTip.SetToolTipText(item.GetItemToolTip());
    }
    public void SelectColor()
    {
         switch (_item.GetRarity())
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
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(OnPress());
    }
    private IEnumerator OnPress()
    {
        _anim.SetTrigger("Click");
        if(!_item.Activate())
        {
            _bgColor.color=StylisticClass.ActiveItemUseInvalid;
        }
        _toolTip.SetToolTipText(_item.GetItemToolTip()); //basically for Stay's coin
        yield return new WaitForSeconds(0.2f);
        SelectColor();
        if(_item.IsPersistent() && !_item.hasBeenActivated())
        {
            _anim.SetBool("Active",true);
        }
    }
    public void ResetAnim() 
    {
        Debug.Log("Reset anim");
        _anim.SetBool("Active",false);
    }   
    public void OnPointerEnter(PointerEventData eventData)
    {
         _anim.SetTrigger("Hover");
    }
}
