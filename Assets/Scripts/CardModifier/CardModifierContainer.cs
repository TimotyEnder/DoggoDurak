using System;
using UnityEngine;
[Serializable]
public class CardModifierContainer
{
    public CardModifierContainer(string ModType) 
    {
        this.ModType = ModType;
    }
    public string ModType;
}
