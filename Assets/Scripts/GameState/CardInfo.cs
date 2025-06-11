using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CardInfo
{
    public  string _suit;
    public  int _suitNumber;
    public int _number;
    public List<CardModifierContainer> _modifiers;

    public CardInfo(string suit, int number) 
    {
        this._suit = suit;
        this._suitNumber = SuitNumber(suit);
        this._number = number;
        this._modifiers= new List<CardModifierContainer>();  
    }
    int SuitNumber(string suit)  //inherent suit  ordering structure here
    {
        switch (suit)
        {
            case "H":
                return 0;
                break;
            case "D":
                return 1;
                break;
            case "S":
                return 2;
                break;
            case "C":
                return 3;
                break;
            default:
                return -1;
                break;
        }
    }
    private static Dictionary<string, CardModifier> modifierStringToType = new Dictionary<string, CardModifier>
    {
        {"Restoring", new RestoringCardMod()},
        {"Bounce", new BounceCardMod()},
        {"Burn", new BurnCardMod()},
        {"Parry", new ParryCardMod()},
        {"Draw", new DrawCardMod()},
        {"Cripple", new CrippleCardMod()},
    };
    public void OnAquire() 
    {
        foreach(CardModifierContainer c in _modifiers) 
        {
            modifierStringToType.GetValueOrDefault(c.ModType).OnAquire();
        }
    }
    public void OnDefendCard(Card defendee, Card defended) 
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            modifierStringToType.GetValueOrDefault(c.ModType).OnDefendCard(defendee, defended);
        }
    }
    public void OnPlayedCard(Card card) 
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            modifierStringToType.GetValueOrDefault(c.ModType).OnPlayedCard(card);
        }
    }
    public void OnReverse(Card card) 
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            modifierStringToType.GetValueOrDefault(c.ModType).OnReverse(card);
        }
    }
    public void addModifier(string ModType) 
    {
        _modifiers.Add(new CardModifierContainer(ModType));
    }
}
