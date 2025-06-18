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
            i.OnLoad();
            if (!i.IsBoss())
            {
                while (i.GetRarity() >= _items.Count)
                {
                    _items.Add(new List<Item>());
                }
                _items[i.GetRarity()].Add(i);
            }
            else
            {
                _bossItems.Add(i);
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
