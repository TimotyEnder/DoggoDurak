using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dvorniashka", menuName = "Encounters/Day1/Dvorniashka")]
public class Dvorniashka : Encounter
{
    public override void InitEncounter()
    {
        encounterName = "Dvorniashka";
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("C", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("D", j, true));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("H", j, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1.5f;
        SetHealth();
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 1;
        description = "A standard Dvorniashka.";
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
