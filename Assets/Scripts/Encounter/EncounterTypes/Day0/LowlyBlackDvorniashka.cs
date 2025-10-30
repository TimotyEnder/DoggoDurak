using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlyBlackDvorniashka", menuName = "Encounters/Day0/LowlyBlackDvorniashka")]
public class LowlyBlackDvorniashka : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 2; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("C", j, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1;
        health = 20;
        trumpSuit = 'H';
        icon = null;
        boss = false;
        day = 0;
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
}
