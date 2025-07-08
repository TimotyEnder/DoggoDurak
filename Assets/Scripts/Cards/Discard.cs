using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{
    List<CardInfo> _playerCards;
    List<CardInfo> _opponentCards;
    public void Start()
    {
        _opponentCards = new List<CardInfo>();
        _playerCards = new List<CardInfo>();    
    }
    public void AddCard(CardInfo card) 
    {
        if (card._opponentCard)
        {
            _opponentCards.Add(card);
        }
        else 
        {
            _playerCards.Add(card);
        }
    }
    public List<CardInfo> GetOpponentDiscard() 
    {
        // Create a new list with the same elements (shallow copy)
        List<CardInfo> returnList = new List<CardInfo>(_opponentCards);

        // Clear the original list
        _opponentCards.Clear();


        return returnList;
    }
    public List<CardInfo> GetPlayerDiscard()
    {
        // Create a new list with the same elements (shallow copy)
        List<CardInfo> returnList = new List<CardInfo>(_playerCards);

        // Clear the original list
        _playerCards.Clear();


        return returnList;
    }
}
