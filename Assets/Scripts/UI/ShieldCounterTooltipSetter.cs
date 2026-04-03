using UnityEngine;

class ShieldCounterTooltipSetter:MonoBehaviour
{
    private ToolTip _thisToolTip;
    void Awake()
    {
        _thisToolTip= this.GetComponent<ToolTip>();
    }
    void Start()
    {
        _thisToolTip.SetTooltipActiveState(true);
        _thisToolTip.SetToolTipText($"{StylisticClass.Shield}");
    }
}