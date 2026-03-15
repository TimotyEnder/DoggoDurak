using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DebugEncounter", menuName = "Encounters/Debug")]
public class DebugEncounter : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 15; j++)
                    {
                        //_deck.Add(new CardInfo("C", j,true));
                        deck.Add(new CardInfo("L", 0,true)); //debug

                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        //_deck.Add(new CardInfo("S", j,true));
                        deck.Add(new CardInfo("L", 0,true)); //debug
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        //_deck.Add(new CardInfo("D", j,true));
                        deck.Add(new CardInfo("L", 0,true));  //debug
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        //_deck.Add(new CardInfo("H", j,true));
                        deck.Add(new CardInfo("L", 0,true));  //debug
                    }
                    break;
            }
        }
        goldRewardMod = 0;
        health = 69;
        trumpSuit = 'S';
        icon = null;
        boss = false;
        day = 0;
        foreach(CardInfo c in deck)
        {
        c.AddModifier("Draw");
        }
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
        
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }

    public override void AddRules()
    {
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
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
