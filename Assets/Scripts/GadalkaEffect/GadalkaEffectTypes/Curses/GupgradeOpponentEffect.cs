using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GupgradeOpponentEffect", menuName = "GadalkaEffect/Curse/GupgradeOpponentEffect")]
class GupgradeOpponentEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._opponentCardUpgradeDefault+=1;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=3;
        SelectedAmount= 1;
        this.effectId="GupgradeOpponentEffect";
        this.descriptionText=$"All opponent's cards gain {StylisticClass.HighLight}+1{StylisticClass.HighLightClose}";
    }
}