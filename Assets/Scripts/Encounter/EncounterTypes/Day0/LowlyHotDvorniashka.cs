using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlyHotDvorniashka", menuName = "Encounters/Day0/LowlyHotDvorniashka")]
public class LowlyHotDvorniashka:Encounter
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
            if (c._number%2==0)
            {
                c.AddModifier("Burn");
            }
        }
        goldRewardMod = 1;
        health = 20;
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 0;
        description = "A lowly but hot Dvorniashka that burns with its claws.";
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
