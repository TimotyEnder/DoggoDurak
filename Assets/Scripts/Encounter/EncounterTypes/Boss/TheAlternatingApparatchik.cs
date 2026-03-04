using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TheAlternatingApparatchik", menuName = "Encounters/Boss-Day1/TheAlternatingApparatchik")]
public class TheAlternatingApparatchik : Encounter
{
    private bool evenTurn=false;
    public override void InitEncounter()
    {
        day=0;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Alternating Apparatchik";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        this.description="The does not know what he believes in  himself.";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule(compileTurnText()+" Turn"); //0
       AddRule($"During an {StylisticClass.HighLight} even {StylisticClass.HighLightClose} turn all {StylisticClass.HighLight} even {StylisticClass.HighLightClose}cards played {StylisticClass.HighLight}heal 5hp{StylisticClass.HighLightClose}"); //1
       AddRule($"During an {StylisticClass.HighLight} odd {StylisticClass.HighLightClose} turn all {StylisticClass.HighLight} odd {StylisticClass.HighLightClose}cards played {StylisticClass.HighLight}heal 5hp{StylisticClass.HighLightClose}"); //2
       AddRule($"At the end of an {StylisticClass.HighLight}even{StylisticClass.HighLightClose} turn, you recieve {StylisticClass.DamageNumber(10)} per {StylisticClass.HighLight}odd{StylisticClass.HighLight} card in your hand");//3
       AddRule($"At the end of an {StylisticClass.HighLight}odd{StylisticClass.HighLightClose} turn, you recieve {StylisticClass.DamageNumber(10)} per {StylisticClass.HighLight}even{StylisticClass.HighLight} card in your hand");//4
    }
    private string compileTurnText()
    {
        if(evenTurn)
        {
            return "<b>Even</b>/Odd";
        }
        else
        {
            return "Even/<b>Odd</b>";
        }
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
        if(!card.GetCardInfo()._opponentCard)
        {
            if(evenTurn && card.GetCardInfo().IsEven())
            {
               GameHandler.Instance.HealPlayer(5);
               ShakeRule(2); 
            }
            else if(!evenTurn && card.GetCardInfo().IsOdd())
            {
                GameHandler.Instance.HealPlayer(5);
                ShakeRule(3);
            }
            
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard)
        {
            if(evenTurn && card.GetCardInfo().IsEven())
            {
               GameHandler.Instance.HealPlayer(5);
               ShakeRule(2); 
            }
            else if(!evenTurn && card.GetCardInfo().IsOdd())
            {
                GameHandler.Instance.HealPlayer(5);
                ShakeRule(3);
            }
            
        }
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        Debug.Log("Even cards:"+GameHandler.Instance.PlayerEvenCardsInHand());
        Debug.Log("Odd cards:"+GameHandler.Instance.PlayerOddCardsInHand());
        if(evenTurn)
        {
            if(GameHandler.Instance.PlayerOddCardsInHand()>0)
            {
                GameHandler.Instance.DamagePlayer(GameHandler.Instance.PlayerOddCardsInHand()*10);
            }
            ShakeRule(0);
        }
        if(!evenTurn)
        {
            if(GameHandler.Instance.PlayerEvenCardsInHand()>0)
            {
                GameHandler.Instance.DamagePlayer(GameHandler.Instance.PlayerEvenCardsInHand()*10);
            }
            ShakeRule(1);
        }
        if(evenTurn)
        {
            evenTurn=false;
        }
        else
        {
            evenTurn=true;
        }
        UpdateRules();
        ShakeRule(0);
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }
}