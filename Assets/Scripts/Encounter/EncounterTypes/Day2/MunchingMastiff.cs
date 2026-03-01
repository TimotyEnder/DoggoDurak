using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MunchingMastiff", menuName = "Encounters/Day2/MunchingMastiff")]
public class MunchingMastiff : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Munching Mastiff";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        foreach(CardInfo card in deck)
        {
            if(card.IsEven())
            {
                card.AddModifier("Restoring");
            }
        }
        this.description="Does not stop munchin'";
        hasRules=true;
        AddRule("The opponent restores 2hp and the end of each turn."); //0
    }

    public override void OnCardDiscarded(CardInfo card)
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
        GameHandler.Instance.HealOpponent(2);
    }

    public override void SetPlayPermissions()
    {
        
    }
}