using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GconsumableChanceDecEffect", menuName = "GadalkaEffect/Curse/GconsumableChanceDecEffect")]
class GconsumableChanceDecEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._consumableDropRate=(GameHandler.Instance.GetGameState()._consumableDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._consumableDropRate-selectedChance;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*7;
        this.cost=roll;
        this.descriptionText=$"Chance for consumable items in encounter rewards -{selectedChance}% Total chance becomes {((GameHandler.Instance.GetGameState()._consumableDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._consumableDropRate-selectedChance)}%";
        
    }
}