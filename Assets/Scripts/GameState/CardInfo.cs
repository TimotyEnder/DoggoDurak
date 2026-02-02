using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
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
    public Card _card;

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
    public void AssignCard(Card card) 
    {
        _card = card;
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
    static public string RandomSuit()
    {
        int random = UnityEngine.Random.Range(1, 4);
        switch (random)
        {
            case 1:
                return "H";
            case 2:
                return "D";
            case 3:
                return "S";
            case 4:
                return "C";
            default:
                return "ERROR";
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
    public static Dictionary<string, int> modifierMaxCopies = new Dictionary<string, int>  //-1 equals infinite copies
    {
        {"Restoring", 1},
        {"Bounce", 1},
        {"Burn", -1},
        {"Parry", 1},
        {"Draw", -1},
        {"Cripple", -1},
        {"Spiky", -1},
    };
    public static Dictionary<string, string> modifierColors = new Dictionary<string, string> 
    {
        {"Restoring", StylisticClass.RestoringColor},
        {"Bounce", StylisticClass.BounceColor},
        {"Burn", StylisticClass.BrunColor},
        {"Parry",StylisticClass.ParryColor},
        {"Draw", StylisticClass.DrawColor},
        {"Cripple", StylisticClass.CrippleColor},
        {"Spiky", StylisticClass.SpikyColor},
    };
    private static Dictionary<string, string> modifierToStyleString = new Dictionary<string, string> 
    {
        {"Restoring", StylisticClass.RestoringString},
        {"Bounce", StylisticClass.BounceString},
        {"Burn", StylisticClass.BurnString},
        {"Parry", StylisticClass.ParryString},
        {"Draw", StylisticClass.DrawString},
        {"Cripple", StylisticClass.CrippleString},
        {"Spiky", StylisticClass.SpikyString},
    };
    private static Dictionary<string, string> modifierToDescription = new Dictionary<string, string>
    {
        {"Restoring", "Defend with this card to gain health equal to the difference of values between the defending and defended cards."},
        {"Bounce", "When defending, this card does  damage  equal  to the difference of values between the defending and defended cards."},
        {"Burn", "Deal 1 damage for each burn modifier on the card."},
        {"Parry", "Reverse with this card to deal that cards value as damage."},
        {"Draw", "Draws 1 card for each draw modifier on the card when played."},
        {"Cripple", "Makes opponent discard 1 card for each cripple modifier on the card when played."},
        {"Spiky", "When this card is defended deal 1 damage for each spiky modifier of the card to the defending player."},
    };
    private static Dictionary<string, string> suitFullName = new Dictionary<string, string>
    {
        {"C"," of Clubs"},
        {"D"," of Diamonds"},
        {"H"," of Hearts"},
        {"S"," of Spades"}
    };
    private static Dictionary<string, string> suitToColor = new Dictionary<string, string>
    {
        {"C","<color=white>"},
        {"D","<color=red>"},
        {"H","<color=red>"},
        {"S","<color=white>"}
    };
    private static Dictionary<int, string> numberFullName = new Dictionary<int, string>
    {
        {6,"Six"},
        {7,"Seven"},
        {8,"Eight"},
        {9,"Nine"},
        {10,"Ten"},
        {11,"Jack"},
        {12,"Queen"},
        {13,"King"},
        {14,"Ace"},
    };
    public async  void OnAquire() 
    {
        foreach(CardModifierContainer c in _modifiers) 
        {
            if(modifierStringToType.GetValueOrDefault(c.ModType).OnAquire())
            {
                if (_card != null)
                {
                    _card.Bling();
                    _card.SpawnModifierEffect(c);
                }
                await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeAnim()));
            }
        }
    }
    public async void OnDefendCard(Card defendee, Card defended) 
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            if (modifierStringToType.GetValueOrDefault(c.ModType).OnDefendCard(defendee, defended)) 
            {
                if (_card != null)
                {
                    _card.Bling();
                    _card.SpawnModifierEffect(c);
                }
                await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeAnim()));
            }
        }
    }
    public async void OnPlayedCard(Card card)
    {
        var modifiersCopy = new List<CardModifierContainer>(_modifiers);
        foreach (CardModifierContainer c in modifiersCopy)
        {
            if (modifierStringToType.GetValueOrDefault(c.ModType).OnPlayedCard(card)) 
            {
                if (_card != null)
                {
                    _card.Bling();
                    _card.SpawnModifierEffect(c);
                }
                await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeAnim()));
            }
        }
    }
    public async void OnReverse(Card card) 
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            if (modifierStringToType.GetValueOrDefault(c.ModType).OnReverse(card)) 
            {
                if (_card != null)
                {
                    _card.Bling();
                    _card.SpawnModifierEffect(c);
                }
                await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeAnim()));
            }
        }
    }
    public async void OnBeingDefended(Card cardDefendingThis)
    {
        foreach (CardModifierContainer c in _modifiers)
        {
            if (modifierStringToType.GetValueOrDefault(c.ModType).OnBeingDefended(cardDefendingThis)) 
            {
                if (_card != null)
                {
                    _card.Bling();
                    _card.SpawnModifierEffect(c);
                }
                await UniTask.Delay(System.TimeSpan.FromSeconds(DelayHandler.GiveDelayTimeAnim()));
            }
        }
    }
    public void AddModifier(string ModType) 
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
        _modifierStacks= new Dictionary<string, int>();
        foreach(CardModifierContainer c in _modifiers) 
        {
            if(!_modifierStacks.ContainsKey(c.ModType))
            {
                _modifierStacks[c.ModType] = 0;
            }
            _modifierStacks[c.ModType] += 1;
        }
    }
    public string CompileTooltipDescription() 
    {
        string returnString = "";
        returnString += "<size="+SettingsState.ToolTipFontSizeTitle+">"+suitToColor[_suit]+"<align=center>"+ numberFullName[_number] + suitFullName[_suit] + "</align></size>" + "\n";
        foreach (KeyValuePair<string, int> entry in _modifierStacks) 
        {
            if(modifierMaxCopies[entry.Key]==1)
            {
                returnString+= $"{modifierColors[entry.Key]}<size="+SettingsState.ToolTipFontSizeText+"><align=left>" + modifierToStyleString[entry.Key] + " (" + modifierToDescription[entry.Key] + ")</align></size></color> \n";
            }
            else
            {
                returnString+= $"{modifierColors[entry.Key]}<size="+SettingsState.ToolTipFontSizeText+"><align=left>"+ modifierToStyleString[entry.Key] + " " + entry.Value + " (" + modifierToDescription[entry.Key] + ")"+"</align></size></color> \n";
            }
        }
        return returnString;
    }
    public override string ToString() // for debug purposes
    {
        return numberFullName[_number] + suitFullName[_suit];
    }
}
