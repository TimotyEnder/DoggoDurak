using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
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
