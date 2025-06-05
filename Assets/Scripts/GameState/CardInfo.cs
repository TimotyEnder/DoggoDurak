using System;
using UnityEngine;
[Serializable]
public class CardInfo
{
    public  string _suit;
    public  int _suitNumber;
    public int _number;

    public CardInfo(string suit, int number) 
    {
        this._suit = suit;
        this._suitNumber = SuitNumber(suit);
        this._number = number;
    }
    int SuitNumber(string suit)  //inherent suit  ordering structure here
    {
        switch (suit)
        {
            case "H":
                return 0;
                break;
            case "D":
                return 1;
                break;
            case "S":
                return 2;
                break;
            case "C":
                return 3;
                break;
            default:
                return -1;
                break;
        }
    }
}
