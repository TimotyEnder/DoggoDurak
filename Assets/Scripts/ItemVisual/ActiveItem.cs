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
        StartCoroutine(OnPress());
    }
    private IEnumerator OnPress()
    {
        _anim.SetTrigger("Click");
        _item.Activate();
        yield return new WaitForSeconds(0.2f);
        if(_item.IsPersistent())
        {
            _anim.SetBool("Active",true);
        }
    }
    public void ResetAnim() 
    {
        _anim.SetBool("Active",false);
    }   
    public void OnPointerEnter(PointerEventData eventData)
    {
         _anim.SetTrigger("Hover");
    }
}
