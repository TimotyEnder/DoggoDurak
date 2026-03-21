using System;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(fileName = "GlegendaryShopChanceEffect", menuName = "GadalkaEffect/Curse/GlegendaryShopChanceEffect")]
class GlegendaryShopChanceEffect : GadalkaEffectInfo
{
    int selectedChance;
    public override void ExecuteEffect()
    {
       GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate -= (int)(GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate * (selectedChance / 100.0));
    }

    public override void InitEffect()
    {
        this.blessing=false;
        int roll = UnityEngine.Random.Range(1,3);
        selectedChance=roll*10;
        this.cost=roll;
        this.effectId="GconsumableChanceDecEffect";
        this.descriptionText=$"Chance for consumable items in encounter rewards -{selectedChance}% Total chance becomes {GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate - (int)(GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate * (selectedChance / 100.0))}%";
        
    }
}