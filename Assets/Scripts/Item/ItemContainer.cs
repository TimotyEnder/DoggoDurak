using System;
using UnityEngine;
[Serializable]
public class ItemContainer
{
    public string ItemID;
    public string SerializedData;

    public ItemContainer(string itemID, string serializedData)
    {
        ItemID = itemID;
        SerializedData = serializedData;
    }
}
