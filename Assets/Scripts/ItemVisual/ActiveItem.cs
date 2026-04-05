using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActiveItem:MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,BlingableVisualItem
{
    private Item _item;
    [SerializeField]
    private Sprite _itemIcon;
    private ToolTip _toolTip;
    [SerializeField]
    private Image _bgColor;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private TextMeshProUGUI _itemName;



    public void AssignItem(Item item)
    {
        item.AssignInventoryItem(this);
        _itemName.text=item.GetSpacedItemName();
        _toolTip = GetComponent<ToolTip>();
        this._item = item;
        SelectColor();
        this._itemIcon = item.GetIcon();
        _toolTip.SetToolTipText(item.GetItemToolTip());
        foreach(SubToolTip st in item.GetSubToolTips())
        {
            _toolTip.AddSubToolTip(st);
        }
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
        if(_item.hasBeenActivated())
        {
            _bgColor.color=new Color(_bgColor.color.r,_bgColor.color.g,_bgColor.color.b,0.5f);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(OnPress());
    }
    private IEnumerator OnPress()
    {
        bool FailedToActivate=false;
        Scene currentScene = SceneManager.GetActiveScene();
        _anim.SetTrigger("Click");
        if((currentScene.name == "Rest") || !_item.Activate())
        {
            _bgColor.color=StylisticClass.ActiveItemUseInvalid;
            FailedToActivate=true;
        }
        _toolTip.SetToolTipText(_item.GetItemToolTip()); //basically for Stay's coin
        yield return new WaitForSeconds(0.2f);
        SelectColor();
        if(_item.IsPersistent()&&!FailedToActivate)
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
    public void Bling()
    {
        _anim.SetTrigger("Click");
    }
}
