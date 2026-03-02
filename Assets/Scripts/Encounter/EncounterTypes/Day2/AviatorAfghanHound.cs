using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AviatorAfghanHound", menuName = "Encounters/Day2/AviatorAfghanHound")]
public class AviatorAfghanHound : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Aviator Afghan Hound";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        AddRandomModifierToDeck(20,"Bounce");
        this.description="Respected and feared army pilot.";
        hasRules=true;
        
    }
    public override void AddRules()
    {
        AddRule("Bounce effects deal " + StylisticClass.DamageNumber(4) + " more."); //0
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
        if (fromMod == "Bounce")
        {
            GameHandler.Instance.DamagePlayer(4,true);
            ShakeRule(0);
        }
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
}