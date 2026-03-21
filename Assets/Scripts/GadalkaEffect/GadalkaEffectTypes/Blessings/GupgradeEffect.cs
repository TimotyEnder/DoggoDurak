using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GupgradeEffect", menuName = "GadalkaEffect/Blessing/GupgradeEffect")]
class GupgradeEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        UpgradeRandomCards(SelectedAmount,1);
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 10 * roll;
        this.effectId="GupgradeEffect";
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.HighLight}+1{StylisticClass.HighLightClose}";
    }
}