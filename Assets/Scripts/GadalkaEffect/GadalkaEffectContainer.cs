using System;
using UnityEngine;
[Serializable]
public class GadalkaEffectContainer
{
    public string EffectID;
    public string SerializedData;

    public GadalkaEffectContainer(string effectID, string serializedData)
    {
        EffectID = effectID;
        SerializedData = serializedData;
    }
}
