using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlyRedDvorniashka", menuName = "Encounters/Day0/LowlyRedDvorniashka")]
public class LowlyRedDvorniashka:Encounter
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
                        deck.Add(new CardInfo("H", j,true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("D", j, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1;
        SetHealth();
        trumpSuit = 'S';
        icon = null;
        boss = false;
        day = 0;
        description = "A lowly red furred Dvorniashka.";
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
