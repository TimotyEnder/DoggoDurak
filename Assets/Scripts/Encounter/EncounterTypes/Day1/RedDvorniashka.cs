using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RedDvorniashka", menuName = "Encounters/Day1/RedDvorniashka")]
public class RedDvorniashka : Encounter
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
                        deck.Add(new CardInfo("H", j, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 12; j++)
                    {
                        deck.Add(new CardInfo("D", j, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1.5f;
        health = 40;
        trumpSuit = 'S';
        icon = null;
        boss = false;
        day = 0;
    }
}
