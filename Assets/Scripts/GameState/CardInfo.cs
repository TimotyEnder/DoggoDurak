using UnityEngine;

public class CardInfo
{
    private string _suit;
    private int number;

    public CardInfo(string suit, int number) 
    {
        this._suit = suit;
        this.number = number;
    }
    public string getSuit() 
    {
        return _suit;
    }
    public int getNumber()
    {
        return number;
    }
}
