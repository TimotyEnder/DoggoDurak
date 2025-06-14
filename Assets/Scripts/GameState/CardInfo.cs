using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CardInfo
{
    public string _suit;
    public int _suitNumber;
    public int _number;
    public List<CardModifierContainer> _modifiers;
    public bool _opponentCard;
    public Dictionary<string, int> _modifierStacks;

    public CardInfo(string suit, int number)
    {
        this._suit = suit;
        this._suitNumber = SuitNumber(suit);
        this._number = number;
        this._modifiers = new List<CardModifierContainer>();
        this._opponentCard = false;
        this._modifierStacks = new Dictionary<string, int>();
    }
    public CardInfo(string suit, int number, bool opp) //to initialize enemy cards
    {
        this._suit = suit;
        this._suitNumber = SuitNumber(suit);
        this._number = number;
        this._modifiers = new List<CardModifierContainer>();
        this._opponentCard = opp;
        this._modifierStacks = new Dictionary<string, int>();
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
        {"Spiky", new SpikyCardMod()},
    };
    private static Dictionary<string, int> modifierMaxCopies = new Dictionary<string, int>  //-1 equals infinite copies
    {
        {"Restoring", 1},
        {"Bounce", 1},
        {"Burn", -1},
        {"Parry", 1},
        {"Draw", -1},
        {"Cripple", -1},
        {"Spiky", -1},
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
    public void OnBeingDefended(Card cardDefendingThis)
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            modifierStringToType.GetValueOrDefault(c.ModType).OnBeingDefended(cardDefendingThis);
        }
    }
    public void addModifier(string ModType) 
    {
        if (modifierMaxCopies[ModType]==-1 || !_modifierStacks.ContainsKey(ModType) || _modifierStacks[ModType] < modifierMaxCopies[ModType]) 
        {
            _modifiers.Add(new CardModifierContainer(ModType));
            if (!_modifierStacks.ContainsKey(ModType))
            {
                _modifierStacks[ModType] = 0;
            }
            _modifierStacks[ModType] += 1;
        }
    }
    public void UpdateModifiers() 
    {
        _modifierStacks.Clear();
        foreach(CardModifierContainer c in _modifiers) 
        {
            if(!_modifierStacks.ContainsKey(c.ModType))
            {
                _modifierStacks[c.ModType] = 0;
            }
            _modifierStacks[c.ModType] += 1;
        }
    }
}
