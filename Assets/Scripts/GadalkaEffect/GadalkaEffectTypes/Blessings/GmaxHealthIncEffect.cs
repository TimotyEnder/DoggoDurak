using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GmaxHealthIncEffect", menuName = "GadalkaEffect/Blessing/GmaxHealthIncEffect")]
class GmaxHealthIncEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.SetMaxHealth(SelectedAmount);
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= 20 * roll;
        this.effectId="GmaxHealthIncEffect";
        this.descriptionText=$"Max health +{SelectedAmount}";
    }
}