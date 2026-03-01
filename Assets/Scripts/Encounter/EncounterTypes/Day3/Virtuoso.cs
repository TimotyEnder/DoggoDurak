using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Virtuoso", menuName = "Encounters/Day3/Virtuoso")]
public class Virtuoso : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Virtuoso";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        foreach(CardInfo card in deck)
        {
            for (int i = 0; i < 5; i++)
            {
                card.AddModifier("Burn");
            }
        }
        this.description="How many cards?!!";
        hasRules=true;
        GameHandler.Instance.GetGameState()._enemyHandSize = 20; 
    }
    public override void AddRules()
    {
       AddRule("If you defend all the cards the opponent attacks with, deal"+StylisticClass.DamageNumber(50)+" to the opponent"); //0
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
        
    }

    public override void OnPlayedCard(Card card)
    {
        
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        if(turnState==1)
        {
            if(GameHandler.Instance.GetUnblockedCards()==0)
            {
                GameHandler.Instance.DamageOpponent(50,false,"Virtuoso");
            }
        }
    }

    public override void SetPlayPermissions()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}