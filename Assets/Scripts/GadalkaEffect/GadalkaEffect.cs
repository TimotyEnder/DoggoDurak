using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

class GadalkaEffect:MonoBehaviour, IPointerClickHandler,IPointerEnterHandler
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


    void Awake()
    {
        _thisAnim=GetComponent<Animator>();
    }

    public void MakeGEffect(GadalkaEffectInfo gInfo)
    {
        this._gInfo=gInfo;
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
        Selected=Selected?false:true;
        _selectedGfx.SetActive(Selected?true:false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _thisAnim.SetTrigger("Hover");
    }
}