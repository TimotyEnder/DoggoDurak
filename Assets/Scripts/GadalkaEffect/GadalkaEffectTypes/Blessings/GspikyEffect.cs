using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GspikyEffect", menuName = "GadalkaEffect/Blessing/GspikyEffect")]
class GspikyEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Spiky");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 7 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.SpikyColor}{StylisticClass.SpikyString}{CardInfo.modifierToDescription["Spiky"]}</color>";
    }
}