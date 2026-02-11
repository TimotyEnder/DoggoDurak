using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    public float GetRewardMod() 
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
    public string GetTooltipText()
    {
        return $"<size="+SettingsState.ToolTipFontSizeTitle+"><align=center>"+GetSpacedEncounterName()+"</align></size>\n" +
               $"<size="+SettingsState.ToolTipFontSizeText+"><align=left>"+this.description+"</align></size>";
    }  
    private string GetSpacedEncounterName() 
    {
        return Regex.Replace(this.name,
           "([a-z])([A-Z])|([A-Z])([A-Z][a-z])",
           "$1$3 $2$4");
    }
    protected void SetHealth()
    {
        if(this.boss)
        {
            this.health= 100+50*GameHandler.Instance.GetGameState()._day;
            if(GameHandler.Instance.GetGameState()._encounter!=11)
            {
                //random boss encoutner less health;
                this.health/=3;
            }
            return;
        }
        switch(this.day)
        {
            case 0:
                this.health=40;
                break;
            case 1:
                this.health=60;
                break;
        }
        
    }
}
