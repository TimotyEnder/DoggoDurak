using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GshopRestPointDecreaseEffect", menuName = "GadalkaEffect/Blessing/GshopRestPointDecreaseEffect")]
class GshopRestPointDecreaseEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._shopRpointCost--;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=-1;
        this.effectId="GshopRestPointDecreaseEffect";
        this.descriptionText=$"Shop costs 1 less {StylisticClass.RestPoint}";
    }
}