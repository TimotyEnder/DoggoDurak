using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Scriptable Objects/Encounter")]
public abstract class Encounter : ScriptableObject
{
    private int day;
    private List<CardInfo> _deck;
    private int _health;
    private int goldReward;
    [SerializeField]
    Sprite _icon;
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
        return goldReward;
    }
    public int GetHealth() 
    { 
        return _health;
    }
}
