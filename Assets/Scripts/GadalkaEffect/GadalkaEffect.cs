using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GadalkaEffect:MonoBehaviour, IPointerClickHandler,IPointerEnterHandler
{
    private GadalkaEffectInfo _gInfo;
    [SerializeField]
    private TextMeshProUGUI _descText;
    [SerializeField]
    private  TextMeshProUGUI _rightCtxt;
    [SerializeField]
    private  TextMeshProUGUI _leftCtxt;
    [SerializeField]
    private GameObject _selectedGfx;
    private bool Selected;
    private Animator _thisAnim;
    private GadalkaPanel _panelParent;


    void Awake()
    {
        _thisAnim=GetComponent<Animator>();
    }

    public void MakeGEffect(GadalkaEffectInfo gInfo,GadalkaPanel _gParent)
    {
        this._gInfo=gInfo;
        this._panelParent=_gParent;
        gInfo.AssignGEffect(this);
        UpdateDescText();
        UpdateCostTxt();
    }
    private void UpdateDescText()
    {
        _descText.text=_gInfo.GetDescription();
    }
    public void UpdateCostTxt()
    {
        if(_gInfo.IsBlessing())
        {
            _rightCtxt.gameObject.SetActive(true);
            _rightCtxt.text=_gInfo.GetCost().ToString();
            _rightCtxt.color=Color.red;
        }
        else
        {
            _leftCtxt.gameObject.SetActive(true);
            _leftCtxt.text="+"+_gInfo.GetCost().ToString();
            _leftCtxt.color=Color.green;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _thisAnim.SetTrigger("Click");
        if(Selected)
        {
            _panelParent.UnSelectEffect(this._gInfo);
        }
        else
        {
            _panelParent.SelectEffect(this._gInfo);
        }
        Selected=Selected?false:true;
        _selectedGfx.SetActive(Selected?true:false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _thisAnim.SetTrigger("Hover");
    }
}