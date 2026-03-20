using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GrareShopChanceDecEffect", menuName = "GadalkaEffect/Curse/GrareShopChanceDecEffect")]
class GrareShopChanceDecEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._rareItemInshopDropRate=(GameHandler.Instance.GetGameState()._rareItemInshopDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._rareItemInshopDropRate-selectedChance;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*5+5;
        this.cost=roll;
        this.descriptionText=$"Chance for rare items in encounter rewards -{selectedChance}% Total chance becomes {((GameHandler.Instance.GetGameState()._rareItemInshopDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._rareItemInshopDropRate-selectedChance)}%";
        
    }
}