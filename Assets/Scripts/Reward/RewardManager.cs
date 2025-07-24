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
        for (int i = 0; i < GameHandler.Instance.GetGameState()._maxRewardSelection; i++) 
        {
            int roll = Random.Range(1, 100);
            if (roll <= GameHandler.Instance.GetGameState()._rareItemRewardDropRate)
            {
                itemsDropped.Add(_itemManager.RandomItemWithRarity(1));
            }
            else 
            {
                itemsDropped.Add(_itemManager.RandomItemWithRarity(0));
            }
        }
        Reward toReturn = new Reward(itemsDropped, 0);
        return toReturn;
    }
}
