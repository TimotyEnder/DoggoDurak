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
    [SerializeField] protected string encounterName;
    protected string description;

    private bool HasRules= false;
    private string Rules;
    //additional rewards implement here
    public  string GetRules()
    {
        if(HasRules)
        {
            return Rules;
        }
        else
        {
            return "NONE";
        }
    }
    public abstract void InitEncounter();

    public abstract void OnPlayedCard(Card card);
    public abstract void OnDefendCard(Card card, Card defendedWith);
    public abstract void OnReverse(Card card);
    public abstract void OnDamagePlayer(int amount);
    public void SetPlayPermissions(){}

    public string GetEncounterName() 
    {
        return encounterName;
    }
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
            this.health= 200*(day+1);
        }
        else
        {
            this.health = 50 +(50*day);
        }
    }
    protected void AddRandomModifierToDeck(int amountToMod, string modifier)
    {
        int cardsModded = 0;
        int it = 0;
        string modifierToUse = modifier;
        while (it < deck.Count && cardsModded < amountToMod)
        {
            CardInfo cardToMod = deck[UnityEngine.Random.Range(0, deck.Count - 1)];
            if (!cardToMod._modifierStacks.ContainsKey(modifier))
            {
                cardToMod.AddModifier(modifier);
                cardsModded++;
            }
            it++;
        }
        for (int j = 0; j < amountToMod - cardsModded; j++) //try top add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
        {
            CardInfo cardToMod = deck[UnityEngine.Random.Range(0, deck.Count - 1)];
            cardToMod.AddModifier(modifier);
        }
    }
    protected void initDeck(int upToNum, bool Clubs, bool Spades, bool Diamonds, bool Hearts)
    {
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    if(Clubs)
                    {
                        for (int j = 6; j < upToNum; j++)
                        {
                            deck.Add(new CardInfo("C", j, true));
                        }
                    }
                    break;
                case 1:
                    if(Spades)
                    {
                        for (int j = 6; j < upToNum; j++)
                        {
                            deck.Add(new CardInfo("S", j, true));
                        }
                    }
                    break;
                case 2:
                    if(Diamonds)
                    {
                        for (int j = 6; j < upToNum; j++)
                        {
                            deck.Add(new CardInfo("D", j, true));
                        }
                    }
                    break;
                case 3:
                    if(Hearts)
                    {
                        for (int j = 6; j < upToNum; j++)
                        {
                            deck.Add(new CardInfo("H", j, true));
                        }
                    }
                    break;
            }
        }
    }
}
