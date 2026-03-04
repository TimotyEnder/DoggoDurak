using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TheBreadlineSwindler", menuName = "Encounters/Day2/TheBreadlineSwindler")]
public class TheBreadlineSwindler : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Breadline Swindler";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        AddRandomModifierToDeck(10,"Burn");
        AddRandomModifierToDeck(10,"Bounce");
        AddRandomModifierToDeck(10,"Spiky");
        this.description="Quick hands, watch your cards!";
        hasRules=true;
        
    }
    public override void AddRules()
    {
        AddRule("If the opponent is made to discard a card they take "+StylisticClass.DamageNumber(10)); //0
        AddRule("And the end of each turn you discard you rightmost card");//1
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
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetPlayerCardsInHand()-1,1);
        ShakeRule(1);
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        GameHandler.Instance.DamagePlayer(10);
        ShakeRule(0);
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }
}