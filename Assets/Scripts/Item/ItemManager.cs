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
    public Item RandomItemWithRarity(int rarity)
    {
        if (rarity < _items.Count && _items[rarity].Count > 0)
        {
            return _items[rarity][Random.Range(0, _items[rarity].Count)];
        }
        return null;
    }
}
