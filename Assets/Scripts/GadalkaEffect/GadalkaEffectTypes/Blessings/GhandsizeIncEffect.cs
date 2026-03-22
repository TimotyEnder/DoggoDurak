using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GhandsizeIncEffect", menuName = "GadalkaEffect/Blessing/GhandsizeIncEffect")]
class GhandsizeIncEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._handSize+=SelectedAmount;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=-roll;
        SelectedAmount= roll;
        this.effectId="GhandsizeIncEffect";
        this.descriptionText=$"Hand size +{SelectedAmount}";
    }
}