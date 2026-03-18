using System;
using UnityEngine;
[Serializable]
public class CardModifierContainer
{
    public CardModifierContainer(string ModType, bool Permanent=true) 
    {
        this.ModType = ModType;
        this.Permanent=Permanent;
    }
    public string ModType;
    public bool Permanent;
}
