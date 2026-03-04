using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RavenousRottweiler", menuName = "Encounters/Day2/RavenousRottweiler")]
public class RavenousRottweiler : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Ravenous Rottweiler";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        AddRandomModifierToDeck(15,"Spiky");
        this.description="The hunger in his eyes is terrifying...";
        hasRules=true;
        
    }
    public override void AddRules()
    {
      AddRule("The opponent heals 2hp for each instance of damage they deal."); //0
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
        GameHandler.Instance.HealOpponent(2);
        ShakeRule(0);
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