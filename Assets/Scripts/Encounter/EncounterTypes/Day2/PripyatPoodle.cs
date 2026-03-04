using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PripyatPoodle", menuName = "Encounters/Day2/PripyatPoodle")]
public class PripyatPoodle : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Pripyat Poodle";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        this.description="A poodle with straight hair?! He looks weak but I am starting to feel sick.";
        hasRules=true;
       
    }
    public override void AddRules()
    {
       AddRule("At the end of the turn you recieve" +StylisticClass.DamageNumber(10)); //0
       AddRule("The opponent recieves double damage."); //1
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        GameHandler.Instance.DamageOpponent(amount,true);
        ShakeRule(1);
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
        GameHandler.Instance.DamagePlayer(10);
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