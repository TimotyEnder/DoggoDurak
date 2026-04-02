using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GoppDmgRec", menuName = "GadalkaEffect/Curse/GoppDmgRec")]
class GoppDmgRec : GadalkaEffectInfo
{
    public override void ExecuteEffect()
    {
        GameHandler.Instance.GetGameState()._defaultOpponentsShield+=1;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        this.cost=3;
        this.effectId="GoppDmgRec";
        this.descriptionText=$"All Opponents  recieve {StylisticClass.ShieldNumber(4)}";
    }
}