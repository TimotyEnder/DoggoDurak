using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlySpikyDvorniashka", menuName = "Encounters/Day0/LowlySpikyDvorniashka")]
public class LowlySpikyDvorniashka : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("C", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("D", j, true));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("H", j, true));
                    }
                    break;
            }
        }
        foreach (CardInfo c in deck)
        {
            if (c._number % 2 != 0)
            {
                c.AddModifier("Spiky");
            }
        }
        goldRewardMod = 1;
        SetHealth();
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 0;
        description = "A lowly  Dvorniashka with a spiked collar";
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
