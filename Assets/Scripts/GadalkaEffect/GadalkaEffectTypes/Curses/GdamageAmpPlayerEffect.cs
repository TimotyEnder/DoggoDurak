using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GdamageAmpPlayerEffect", menuName = "GadalkaEffect/Curse/GdamageAmpPlayerEffect")]
class GdamageAmpPlayerEffect : GadalkaEffectInfo
{
    private int SelectedAmount;
    public override void ExecuteEffect()
    {
        GameHandler.Instance.SetPlayerShield(GameHandler.Instance.GetGameState()._playerShield-SelectedAmount);
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll=UnityEngine.Random.Range(1,4);
        this.cost=roll*2+1;
        SelectedAmount = roll*2;
        this.effectId="GdamageAmpPlayerEffect";
        this.descriptionText=$"You recieve {StylisticClass.DamageNumber(SelectedAmount)} more from all sources.";
    }
}