using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HotDog", menuName = "Encounters/Day1/HotDog")]
public class HotDog : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Hot Dog";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true);
        AddRandomModifierToDeck(15,"Burn");
        this.description="He is on fire! No like literally...";
        hasRules=true;
        AddRule("The opponent recieves "+StylisticClass.DamageNumber(5)+"at the end of the turn"); //0
    }

    public override void OnCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
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
        GameHandler.Instance.DamageOpponent(5,true);
    }

    public override void SetPlayPermissions()
    {
        
    }
}