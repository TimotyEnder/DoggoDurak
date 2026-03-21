using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GbounceEffect", menuName = "GadalkaEffect/Blessing/GbounceEffect")]
class GbounceEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Bounce");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        this.effectId="GbounceEffect";
        SelectedAmount= 5 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.BounceColor}{StylisticClass.BounceString}{CardInfo.modifierToDescription["Bounce"]}</color>";
    }
}