using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Resources/Encounter")]
public abstract class Encounter : ScriptableObject
{
    [SerializeField] protected int _day;
    [SerializeField] protected List<CardInfo> _deck;
    [SerializeField] protected int _health;
    [SerializeField] protected int _goldReward;
    [SerializeField] protected char _trumpSuit;
    [SerializeField] protected  Sprite _icon;
    [SerializeField] protected bool _boss;
    //additional rewards implement here

    public abstract void InitEncounter();
    public int GetDay() 
    {
        return _day;
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
    public bool isBoss() 
    {
        return _boss;
    }
}
