using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

class GadalkaEffect:MonoBehaviour, IPointerClickHandler
{
    private GadalkaEffectInfo _gInfo;
    private TextMeshProUGUI _descText;
    [SerializeField]
    private GameObject _selectedGfx;
    private bool Selected;


    void Awake()
    {
        _descText=GetComponentInChildren<TextMeshProUGUI>();
    }

    public void MakeGEffect(GadalkaEffectInfo gInfo)
    {
        this._gInfo=gInfo;
        UpdateDescText();
    }
    private void UpdateDescText()
    {
        _descText.text=_gInfo.GetDescription();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Selected=Selected?false:true;
        _selectedGfx.SetActive(Selected?true:false);

    }
}