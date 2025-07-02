using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlyDvorniashka", menuName = "Encounters/Day0/LowlyDvorniashka")]
public class LowlyDvorniashka : Encounter
{
    public override void InitEncounter()
    {
        deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("C", 10, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("S", 10, true));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("D", 10, true));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 11; j++)
                    {
                        deck.Add(new CardInfo("H", 10, true));
                    }
                    break;
            }
        }
        goldRewardMod = 1;
        health = 69;
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 0;
    }
}
