using System;
using UnityEngine;
[Serializable]
public class ItemContainer
{
    public ItemContainer(string ItemName)
    {
        this.ItemName = ItemName;
    }
    public string ItemName;
}
