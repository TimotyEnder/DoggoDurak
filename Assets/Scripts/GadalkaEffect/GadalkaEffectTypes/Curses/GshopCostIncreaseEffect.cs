using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GshopCostIncreaseEffect", menuName = "GadalkaEffect/Curse/GshopCostIncreaseEffect")]
class GshopCostIncreaseEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._shopRpointCost++;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        this.cost=1;
        this.descriptionText=$"Shop costs 1 more {StylisticClass.RestPoint}";
    }
}