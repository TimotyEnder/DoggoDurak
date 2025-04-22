using UnityEngine;
[System.Serializable]
public class CardInfo
{
    [SerializeField]  
    private string _suit;
    private int _suitNumber;
    [SerializeField]  
    private int number;

    public CardInfo(string suit, int number) 
    {
        this._suit = suit;
        this._suitNumber = SuitNumber(suit);
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
    public int getSuitNumber() 
    {
        return _suitNumber; //for sorting
    }
    int SuitNumber(string suit) 
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
