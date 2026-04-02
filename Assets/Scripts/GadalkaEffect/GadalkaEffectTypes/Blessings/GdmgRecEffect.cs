using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GdmgRecEffect", menuName = "GadalkaEffect/Blessing/GdmgRecEffect")]
class GdmgRecEffect : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._playerShield+=2;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        this.cost=-3;
        this.effectId="GdmgRecEffect";
        this.descriptionText=$"Recieve {StylisticClass.ShieldNumber(3)}";
    }
}