using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{
    public List<Item> items;
    public int goldReward;

    public Reward(List<Item> items, int goldReward)
    {
        this.items = items;
        this.goldReward = goldReward;
    }
}
