using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GpoisonEffect", menuName = "GadalkaEffect/Blessing/GpoisonEffect")]
class GpoisonEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Poison");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 5 * roll;
        this.effectId="GpoisonEffect";
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.PoisonColor}{StylisticClass.PoisonString}{CardInfo.modifierToDescription["Poison"]}</color>";
    }
}