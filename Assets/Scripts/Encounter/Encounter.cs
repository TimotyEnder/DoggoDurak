using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Resources/Encounter")]
public abstract class Encounter : ScriptableObject
{
    [SerializeField] protected int day;
    [SerializeField] protected List<CardInfo> deck;
    [SerializeField] protected int health;
    [SerializeField] protected float goldRewardMod;
    [SerializeField] protected char trumpSuit;
    [SerializeField] protected  Sprite icon;
    [SerializeField] protected bool boss;
    protected string description;
    //additional rewards implement here

    public abstract void InitEncounter();

    public abstract void OnPlayedCard(Card card);
    public abstract void OnDefendCard(Card card, Card defendedWith);
    public abstract void OnReverse(Card card);
    public abstract void OnDamagePlayer(int amount);
    public int GetDay() 
    {
        return day;
    }
    public List<CardInfo> GetDeck()
    {
        return deck;
    }
    public float GetReward() 
    {
        return goldRewardMod;
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
    public string GetDescription()
    {
        return description;
    }
}
