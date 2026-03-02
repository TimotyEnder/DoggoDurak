using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SiberianBearHunter", menuName = "Encounters/Day3/SiberianBearHunter")]
public class SiberianBearHunter : Encounter
{
    public int _damageCur=0;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Siberian Bear Hunter";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        foreach(CardInfo card in deck)
        {
            for (int i = 0; i < 5; i++)
            {
                card.AddModifier("Spiky");
            }
        }
        this.description="Is he becoming sharper!?";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule("For each "+StylisticClass.DamageNumber(5)+" the opponent deals to you, all the cards in his deck currently gain spiky 1"); //0
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
        _damageCur+=amount;
        int toModify = _damageCur / 5;  
        _damageCur = _damageCur % 5;
        if(toModify>0)
        {
            foreach(CardInfo card in deck)
            {
                for (int i = 0; i < toModify; i++)
                {
                    card.AddModifier("Spiky");
                }
            }
        }
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
}