using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private List<List<Item>> _items;
    private List<Item> _bossItems;
    public ItemManager()
    {
        _items = new List<List<Item>>();
        _bossItems = new List<Item>();
        var loadedItems = Resources.LoadAll<Item>("Items");
        foreach (var i in loadedItems)
        {
            Item runtimeItem = Object.Instantiate(i); // Create a safe copy
            runtimeItem.InitItem();
            if (!runtimeItem.IsBoss())
            {
                while (runtimeItem.GetRarity() >= _items.Count)
                {
                    _items.Add(new List<Item>());
                }
                _items[runtimeItem.GetRarity()].Add(runtimeItem);
            }
            else
            {
                _bossItems.Add(runtimeItem);
            }
        }
    }
    public List<Item> RandomItemsWithRarity(int rarity, int amount = 1)
    {
        List<Item> itemsDropped = new List<Item>();
        if (rarity < _items.Count && _items[rarity].Count > 0)
        {
            int[] randomInts = RandomPlus.GenerateUniqueRandomNumbers(0, _items[rarity].Count - 1, amount);
            List<Item> toRem= new List<Item>();
            foreach (int i in randomInts)
            {
                Item itemReturned = Object.Instantiate(_items[rarity][i]);
                itemReturned.InitItem();
                if (rarity > 0)
                {
                    toRem.Add(_items[rarity][i]);
                    Debug.Log("I removed is:"+_items[rarity][i]);
                }
                itemsDropped.Add(itemReturned);
            }
            foreach(Item i in toRem)
            {
                Debug.Log("Removed at:"+i);
                _items[rarity].Remove(i);// no other item rarity apart from common stacks so you should remove it from drop table 
            }
        }
        return itemsDropped;
    }
    public void ReAddItems(List<Item> items)
    {
        foreach (var item in items)
        {
            if (!item.IsBoss())
            {
                _items[item.GetRarity()].Add(item);
            }
             else
            {
                _bossItems.Add(item);
            }
        }
    }
}
