

using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GrareItemEncounterInc", menuName = "GadalkaEffect/Blessing/GrareItemEncounterInc")]
class GrareItemEncounterInc : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._rareItemRewardDropRate += (int)(GameHandler.Instance.GetGameState()._rareItemRewardDropRate * (selectedChance / 100.0));
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*10+10;
        this.cost=-roll;
        this.effectId="GrareItemEncounterInc";
        this.descriptionText=$"Chance for consumable items in encounter rewards +{selectedChance}% Total chance becomes {GameHandler.Instance.GetGameState()._rareItemRewardDropRate + (int)(GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate * (selectedChance / 100.0))}%";
        
    }
}