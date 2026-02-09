using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SiberianBearHunter", menuName = "Encounters/Boss/SiberianBearHunter")]
public class SiberianBearHunter : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 1; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("S", j, true));
                    }
                    break;
            }
        }
        foreach (CardInfo c in deck) 
        {
            for (int i = 0; i < 10; i++)
            {
                c.AddModifier("Spiky");
            }
        }
        goldRewardMod = 2.0f;
        SetHealth();
        trumpSuit = 'D';
        icon = null;
        boss = true;
        day = 0;
        description = "A black furred hunter wearing  Siberian Bearhunting Armor with incredible dagerous spikes";
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
