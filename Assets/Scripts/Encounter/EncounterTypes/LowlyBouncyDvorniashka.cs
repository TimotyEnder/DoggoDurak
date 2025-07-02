using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LowlyBouncyDvorniashka", menuName = "Encounters/Day0/LowlyBouncyDvorniashka")]
public class LowlyBouncyDvorniashka : Encounter
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
                        deck.Add(new CardInfo("C", 10, true));
                    }
                    break;
                case 1:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("S", 10, true));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("D", 10, true));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 10; j++)
                    {
                        deck.Add(new CardInfo("H", 10, true));
                    }
                    break;
            }
        }
        int cardsModded = 0;
        int it = 0;
        int amountToMod = 5;
        string modifier = "Bounce";
        while (it < deck.Count && cardsModded < amountToMod)
        {
            CardInfo cardToMod = deck[Random.Range(0, deck.Count - 1)];
            if (!cardToMod._modifierStacks.ContainsKey(modifier))
            {
                cardToMod.AddModifier(modifier);
                cardsModded++;
            }
            it++;
        }
        for (int j = 0; j < amountToMod - cardsModded; j++) //try top add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
        {
            CardInfo cardToMod = deck[Random.Range(0, deck.Count - 1)];
            cardToMod.AddModifier(modifier);
        }
        goldRewardMod = 1;
        health = 69;
        trumpSuit = 'R';
        icon = null;
        boss = false;
        day = 0;
    }
}
