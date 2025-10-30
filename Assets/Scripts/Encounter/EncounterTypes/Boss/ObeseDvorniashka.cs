using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObeseDvorniashka", menuName = "Encounters/Boss/ObeseDvorniashka")]
public class ObeseDvorniashka : Encounter
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
                        deck.Add(new CardInfo("C", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("D", j, true));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("H", j, true));
                    }
                    break;
            }
        }
        foreach (CardInfo c in deck) 
        {
            c.AddModifier("Restoring");
        }
        goldRewardMod = 2.0f;
        health = 100;
        trumpSuit = 'R';
        icon = null;
        boss = true;
        day = 0;
        description = "An obese Corgi that has mountains of food around it.";
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
