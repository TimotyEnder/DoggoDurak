using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GburnEffect", menuName = "GadalkaEffect/Blessing/GburnEffect")]
class GburnEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Burn");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 7 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.BurnColor}{StylisticClass.BurnString}{CardInfo.modifierToDescription["Burn"]}</color>";
    }
}