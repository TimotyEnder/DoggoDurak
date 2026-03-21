using System;
using UnityEngine;
[Serializable]
public class GadalkaEffectContainer
{
    public string ItemID;
    public string SerializedData;

    public GadalkaEffectContainer(string effectID, string serializedData)
    {
        ItemID = effectID;
        SerializedData = serializedData;
    }
}
