using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GconsumableChanceIncEffect", menuName = "GadalkaEffect/Blessing/GconsumableChanceIncEffect")]
class GconsumableChanceIncEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._consumableDropRate += (int)(GameHandler.Instance.GetGameState()._consumableDropRate * (selectedChance / 100.0));
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*10+10;
        this.cost=-roll;
        this.effectId="GconsumableChanceIncEffect";
        this.descriptionText=$"Chance for consumable items in encounter rewards +{selectedChance}% Total chance becomes {GameHandler.Instance.GetGameState()._consumableDropRate + (int)(GameHandler.Instance.GetGameState()._consumableDropRate * (selectedChance / 100.0))}%";
        
    }
}