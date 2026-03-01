using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StalwartStorozhevaya", menuName = "Encounters/Day2/StalwartStorozhevaya")]
public class StalwartStorozhevaya : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Stalwart Storozhevaya";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        AddRandomModifierToDeck(10,"Burn");
        AddRandomModifierToDeck(10,"Spiky");
        this.description="Incredibly strong looking guard dog. It will be hard to get past his riot shield.";
        hasRules=true;
        AddRule("The opponent recieve "+StylisticClass.DamageNumber(5)+" less from any source."); //0
        GameHandler.Instance.GetGameState()._opponetnDamageReduction = 5;
    }

    public override void OnCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        ShakeRule(0);
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
    }

    public override void SetPlayPermissions()
    {
        
    }
}