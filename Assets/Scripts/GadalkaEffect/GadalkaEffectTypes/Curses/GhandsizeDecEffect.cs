using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GhandsizeDecEffect", menuName = "GadalkaEffect/Curse/GhandsizeDecEffect")]
class GhandsizeDecEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._handSize-=SelectedAmount;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=roll;
        SelectedAmount= roll;
        this.effectId="GhandsizeDecEffect";
        this.descriptionText=$"Hand size -{SelectedAmount}";
    }
}