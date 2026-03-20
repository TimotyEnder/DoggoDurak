using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GrestoringEffect", menuName = "GadalkaEffect/Blessing/GrestoringEffect")]
class GrestoringEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Restoring");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 5 * roll;
        this.descriptionText=$"{SelectedAmount} random cards gain {StylisticClass.RestoringColor}{StylisticClass.RestoringString}{CardInfo.modifierToDescription["Restoring"]}</color>";
    }
}