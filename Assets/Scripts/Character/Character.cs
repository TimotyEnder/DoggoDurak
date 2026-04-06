using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject
{
    protected int startingRubles;
    protected string characterId;
    protected string characterName;
    public abstract List<Item> LoadItems();
    public abstract void InitCharacter();
    public string GetID()
    {
        return this.characterId;
    }
    public int GetStartRub()
    {
        return this.startingRubles;
    }
    public string GetName()
    {
        return this.characterName;
    }
    public int ReturnStartingMoney()
    {
        return this.startingRubles;
    }

}
