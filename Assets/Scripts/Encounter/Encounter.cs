using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Resources/Encounter")]
public abstract class Encounter : ScriptableObject
{
    [SerializeField] protected int day;
    [SerializeField] protected List<CardInfo> deck;
    [SerializeField] protected int health;
    [SerializeField] protected int goldReward;
    [SerializeField] protected char trumpSuit;
    [SerializeField] protected  Sprite icon;
    [SerializeField] protected bool boss;
    //additional rewards implement here

    public abstract void InitEncounter();
    public int GetDay() 
    {
        return day;
    }
    public List<CardInfo> GetDeck()
    {
        return deck;
    }
    public int GetReward() 
    {
        return goldReward;
    }
    public int GetHealth() 
    { 
        return health;
    }
    public char GetTrumpSuit() 
    {
        return trumpSuit;
    }
    public bool IsBoss() 
    {
        return boss;
    }
}
