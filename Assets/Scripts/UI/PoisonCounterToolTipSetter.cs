using UnityEngine;
using UnityEngine.EventSystems;

class PoisonCounterToolTipSetter:MonoBehaviour,IPointerEnterHandler
{
    private ToolTip _thisToolTip;
    public bool opponent;
    void Awake()
    {
        _thisToolTip= this.GetComponent<ToolTip>();
    }
    void Start()
    {
        UpdateToolTip();
    }
    void UpdateToolTip()
    {
        _thisToolTip.SetTooltipActiveState(true);
        if(opponent)
        {
            _thisToolTip.SetToolTipText($"<align=center><size={SettingsState.ToolTipFontSizeText}>Will recieve {StylisticClass.DamageNumber(GameHandler.Instance.GetCurrEncounter().GetPoisonCounters()*(GameHandler.Instance.GetGameState()._modifierAddedEffect["Poison"]+1))} at the end of this turn.</size></align>");
        }
        else
        {
            _thisToolTip.SetToolTipText($"<align=center><size={SettingsState.ToolTipFontSizeText}>You will recieve {StylisticClass.DamageNumber(GameHandler.Instance.GetCurrEncounter().GetPoisonCounters()*1)} and the end of this turn.</size></align>");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateToolTip();
    }
}