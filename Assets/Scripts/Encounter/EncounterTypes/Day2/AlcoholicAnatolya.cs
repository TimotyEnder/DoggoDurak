using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AlcoholicAnatolya", menuName = "Encounters/Day2/AlcoholicAnatolya")]
public class AlcoholicAnatolya : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Alcoholic Anatolya";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        foreach(CardInfo card in deck)
        {
            if(card.IsOdd())
            {
                card.AddModifier("Parry");
            }
        }
        this.description="Is would be disrespectful to not accept his toast...s... every turn.";
        hasRules=true;
        AddRule("Players recieve " + StylisticClass.DamageNumber(2) + " damage for each card discarded"); //0
        AddRule("Players recieve " + StylisticClass.DamageNumber(2) + " damage for each card drawn"); //1
    }

    public override void OnCardDiscarded(CardInfo card)
    {
        if (card._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(2);
        }
        else
        {
            GameHandler.Instance.DamagePlayer(2);
        }
        ShakeRule(0);
    }

    public override void OnCardDrawn(CardInfo card)
    {
        if (card._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(2);
        }
        else
        {
            GameHandler.Instance.DamagePlayer(2);
        }
        ShakeRule(1);
    }

    public override void OnDamageOpponent(int amount)
    {
        
    }

    public override void OnDamagePlayer(int amount)
    {
        
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        
    }

    public override void OnPlayedCard(Card card)
    {
        
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
    }

    public override void SetPlayPermissions()
    {
    }
}