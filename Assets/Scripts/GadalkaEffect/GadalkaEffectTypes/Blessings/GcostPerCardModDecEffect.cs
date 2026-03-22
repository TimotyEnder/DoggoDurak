using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GcostPerCardModDecEffect", menuName = "GadalkaEffect/Blessing/GcostPerCardModDecEffect")]
class GcostPerCardModDecEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._shopCostPerCardMod-=2;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=-1;
        this.effectId="GcostPerCardModIncEffect";
        this.descriptionText=$"Cards in the shop cost {StylisticClass.HighLight}2 rubles less{StylisticClass.HighLightClose} per modifier.";
    }
}