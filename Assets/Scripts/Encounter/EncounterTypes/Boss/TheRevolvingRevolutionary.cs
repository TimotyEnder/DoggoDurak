using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
[CreateAssetMenu(fileName = "TheRevolvingRevolutionary", menuName = "Encounters/Boss-Day1/TheRevolvingRevolutionary")]
public class TheRevolvingRevolutionary : Encounter
{
    private HashSet<string> _suitsPlayedLastTurn;
    public override void InitEncounter()
    {
        day=0;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Revolving Revolutionary";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        _suitsPlayedLastTurn=new HashSet<string>();
        this.description="The does not know what he believes in  himself.";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule($"Suits {StylisticClass.Debuffed} next turn:"+CompileSuitsPlayed()); //0
       AddRule("Suits Played last turn are debuffed"); //1
    }
    public string CompileSuitsPlayed()
    {
        string toRet="";
        foreach(string suit in _suitsPlayedLastTurn)
        {
            toRet+=$"{CardInfo.suitToColor[suit]}{CardInfo.suitFullName[suit].Substring(3)}</color>\n";
        }
        return toRet;
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
    
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        if(!defendedWith.GetCardInfo()._opponentCard && !_suitsPlayedLastTurn.Contains(defendedWith.GetCardInfo()._suit))
        {
            _suitsPlayedLastTurn.Add(defendedWith.GetCardInfo()._suit);
            UpdateRules();
            ShakeRule(0);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && !_suitsPlayedLastTurn.Contains(card.GetCardInfo()._suit))
        {
            _suitsPlayedLastTurn.Add(card.GetCardInfo()._suit);
            UpdateRules();
            ShakeRule(0);
        }
    }

    public override void OnReverse(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && !_suitsPlayedLastTurn.Contains(card.GetCardInfo()._suit))
        {
            _suitsPlayedLastTurn.Add(card.GetCardInfo()._suit);
            UpdateRules();
            ShakeRule(0);
        }
    }

    public override void OnTurnEnd(int turnState)
    {
    }
    public override void SetDebuffs()
    {
        GameHandler.Instance.SetDebuffs(_suitsPlayedLastTurn.ToArray(),true,false);
        _suitsPlayedLastTurn.Clear();
        UpdateRules();
        ShakeRule(1);
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}