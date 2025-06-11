using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameState
{
    public List<CardInfo> _deck;
    public int _gold;
    public int _health;
    public int _maxhealth;
    public int _day;
    public int _encounter;
    public int _restPoints;
    public int _maxrestPoints;
    public int _restRpointCost;
    public GameState() 
    {
        _deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("C", j));

                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("S", j));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("D", j));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("H", j));
                    }
                    break;
            }
        }
        _gold = 0;
        _health = 100;
        _maxhealth = 100;
        _day = 0;
        _encounter = 0;
        _restPoints = 3;
        _maxrestPoints = 3;
        _restRpointCost = 1; //cost to use rest action in the rest tab
    }

}
