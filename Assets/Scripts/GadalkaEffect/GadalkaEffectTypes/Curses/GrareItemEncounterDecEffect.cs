

using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GrareItemEncounterDecEffect", menuName = "GadalkaEffect/Curse/GrareItemEncounterDecEffect")]
class GrareItemEncounterDecEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._rareItemRewardDropRate=(GameHandler.Instance.GetGameState()._rareItemRewardDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._rareItemRewardDropRate-selectedChance;
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*5;
        this.cost=roll;
        this.descriptionText=$"Chance for rare items in encounter rewards -{selectedChance}% Total chance becomes {((GameHandler.Instance.GetGameState()._rareItemRewardDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._rareItemRewardDropRate-selectedChance)}%";
        
    }
}