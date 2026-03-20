using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GparryEffect", menuName = "GadalkaEffect/Blessing/GparryEffect")]
class GparryEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Parry");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 5 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.ParryColor}{StylisticClass.ParryString}{CardInfo.modifierToDescription["Parry"]}</color>";
    }
}