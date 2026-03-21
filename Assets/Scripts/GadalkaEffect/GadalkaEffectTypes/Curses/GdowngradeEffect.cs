using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GdowngradeEffect", menuName = "GadalkaEffect/Curse/GdowngradeEffect")]
class GdowngradeEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        UpgradeRandomCards(SelectedAmount,-1);
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=roll;
        SelectedAmount= 10 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.HighLight}-1{StylisticClass.HighLightClose}";
    }
}