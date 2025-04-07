using UnityEngine;
[System.Serializable]
public class CardInfo
{
    [SerializeField]  private string _suit;
    [SerializeField]  private int number;

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
