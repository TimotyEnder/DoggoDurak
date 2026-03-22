using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GlaikadEffect", menuName = "GadalkaEffect/Blessing/GlaikadEffect")]
class GlaikadEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        AddModToRandomCards(SelectedAmount,"Laika");
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 2 * roll+2;
        this.effectId="GlaikadEffect";
        this.descriptionText=$"{SelectedAmount} random cards become {StylisticClass.Laika}";
    }
}