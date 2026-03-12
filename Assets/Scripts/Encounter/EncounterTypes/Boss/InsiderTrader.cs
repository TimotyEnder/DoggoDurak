using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "InsiderTrader", menuName = "Encounters/Boss-Day2/InsiderTrader")]
public class InsiderTrader : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "InsiderInvestor";
        goldRewardMod = 10f;
        this.health=20;
        initDeck(14,true,true,true,true);
        this.description="Only a strong combine force of attacks will blow through his shield!";
        hasRules=true;
        GameHandler.Instance.GetGameState()._loseToWin=true;
        GameHandler.Instance.GetGameState()._healingAndDamageInverted=true;
    }
   
    public override void AddRules()
    {
        AddRule("The opponent bid on you winning so you need to lose to win a big reward!");//0
        AddRule($"Damage that the opponent does to you heals you");//1
        AddRule($"Affects that heal you, damage you");//2
        AddRule($"And the end of each turn, your health decreases by 10");//3
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
        ShakeRule(1);
    }

    public override void OnDefendCard(Card card, Card defended)
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
       GameHandler.Instance.DamagePlayer(10,fromMod:"InsiderTrader");
       ShakeRule(3);
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        ShakeRule(2);
    }

    public override int AddToDamagePlayer(int amount, string fromMod = "")
    {
        return amount;
    }

    public override int AddToDamageOpponent(int amount, string fromMod = "")
    {
        return amount;
    }
}