using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GcostPerCardModIncEffect", menuName = "GadalkaEffect/Curse/GcostPerCardModIncEffect")]
class GcostPerCardModIncEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._shopCostPerCardMod+=2;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=1;
        this.effectId="GcostPerCardModIncEffect";
        this.descriptionText=$"Cards in the shop cost {StylisticClass.HighLight}2 {StylisticClass.RubleSign} more{StylisticClass.HighLightClose} per modifier.";
    }
}