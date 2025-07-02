using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DefaultEncounter", menuName = "Encounters/Default")]
public class DefaultEncounter : Encounter
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
                        deck.Add(new CardInfo("C", j,true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        deck.Add(new CardInfo("S", j,true));
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
                        deck.Add(new CardInfo("H", j,true));
                    }
                    break;
            }
        }
        goldRewardMod = 0;
        health = 40;
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 0;
    }
}
