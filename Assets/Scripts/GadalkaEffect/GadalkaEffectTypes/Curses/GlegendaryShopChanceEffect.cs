using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GlegendaryShopChanceEffect", menuName = "GadalkaEffect/Curse/GlegendaryShopChanceEffect")]
class GlegendaryShopChanceEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate=(GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate-selectedChance;
    }

    public override void InitEffect()
    {
        this.blessing=true;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*4;
        this.cost=roll+1;
        this.descriptionText=$"Chance for legendary items in encounter rewards -{selectedChance}% Total chance becomes {((GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate-selectedChance==0)?0:GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate-selectedChance)}%";
        
    }
}