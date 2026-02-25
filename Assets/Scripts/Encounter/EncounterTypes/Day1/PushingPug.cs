using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PushingPug", menuName = "Encounters/Day1/PushingPug")]
public class PushingPug : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Pushing Pug";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true);
        AddRandomModifierToDeck(5,"Restoring");
        this.description="A Pushy Pug.";
        hasRules=true;
        AddRule("Defending player receives "+StylisticClass.DamageNumber(1)+" for each unblocked card."); //0
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
        int unblockedCards= GameHandler.Instance.GetUnblockedCards();
        if(turnState==0)
        {
            GameHandler.Instance.DamageOpponent(unblockedCards,true);
        }
        else
        {
            GameHandler.Instance.DamagePlayer(unblockedCards,true);
        }
        ShakeRule(0);
    }
}