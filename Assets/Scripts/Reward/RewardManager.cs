using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager
{
    private ItemManager _itemManager;

    public RewardManager() 
    {
        _itemManager = new ItemManager();
    }

    public Reward GenerateReward() 
    {
    List<Item> itemsDropped=new List<Item>();
        int roll = Random.Range(1, 100);
        if (roll <= GameHandler.Instance.GetGameState()._rareItemRewardDropRate)
        {
            itemsDropped.AddRange(_itemManager.RandomItemsWithRarity(1, 1));
            itemsDropped.AddRange(_itemManager.RandomItemsWithRarity(0, GameHandler.Instance.GetGameState()._maxRewardSelection-1));
        }
        else 
        {
            itemsDropped.AddRange(_itemManager.RandomItemsWithRarity(0, GameHandler.Instance.GetGameState()._maxRewardSelection));
        }
        Reward toReturn = new Reward(itemsDropped, 0);
        return toReturn;
    }
}
