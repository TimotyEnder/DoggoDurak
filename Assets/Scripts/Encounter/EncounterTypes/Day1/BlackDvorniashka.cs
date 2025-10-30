using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BlackDvorniashka", menuName = "Encounters/Day1/BlackDvorniashka")]
public class BlackDvorniashka : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 2; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("C", j, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1.5f;
        health = 40;
        trumpSuit = 'D';
        icon = null;
        boss = false;
        day = 1;
        description = "A black furred Dvorniashka.";
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
