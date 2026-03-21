using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GcostPerCardModDecEffect", menuName = "GadalkaEffect/Curse/GcostPerCardModDecEffect")]
class GcostPerCardModDecEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._shopRpointCost++;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=1;
        this.descriptionText=$"Cards in the shop cost {StylisticClass.HighLight}2 rubles more{StylisticClass.HighLightClose} per modifier.";
    }
}