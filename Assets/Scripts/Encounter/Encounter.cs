using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Scriptable Objects/Encounter")]
public abstract class Encounter : ScriptableObject
{
    protected int day;
    protected List<CardInfo> _deck;
    protected int _health;
    protected int _goldReward;
    protected char _trumpSuit;
    [SerializeField]
    protected  Sprite _icon;
    //additional rewards implement here

    public abstract void InitEncounter();
    public int GetDay() 
    {
        return day;
    }
    public List<CardInfo> GetDeck()
    {
        return _deck;
    }
    public int GetReward() 
    {
        return _goldReward;
    }
    public int GetHealth() 
    { 
        return _health;
    }
    public char GetTrumpSuit() 
    {
        return _trumpSuit;
    }
}
