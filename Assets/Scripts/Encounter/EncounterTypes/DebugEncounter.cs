using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DebugEncounter", menuName = "Encounters/Debug")]
public class DebugEncounter : Encounter
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
                        deck.Add(new CardInfo("C", 10));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("S", 10));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("D", 10));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("H", 10));
                    }
                    break;
            }
        }
        goldReward = 0;
        health = 69;
        trumpSuit = 'S';
        icon = null;
        boss = false;
        day = 0;
    }
}
