using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Discard : MonoBehaviour
{
    List<Card> _playerCards;
    List<Card> _opponentCards;
    [SerializeField]
    private Button _discardButton;
    [SerializeField]
    private Button _discardExitButton;
    [SerializeField]
    private GameObject _discardPanel;
    [SerializeField]
    private GameObject _playerDiscardContent;
    [SerializeField]
    private GameObject _opponentDiscardContent;
    [SerializeField]
    private GameObject _cardPrefab;
    public void Start()
    {
        _opponentCards = new List<Card>();
        _playerCards = new List<Card>();
    }
    public void AddCard(Card card) 
    {
        if (card.GetCardInfo()._opponentCard)
        {
            _opponentCards.Add(card);
        }
        else 
        {
            _playerCards.Add(card);
        }
    }
    public void WipeDiscard()
    {  
        foreach (Card c in _playerCards)
        {
            Destroy(c.gameObject);
        }
    }   
    public List<Card> GetOpponentDiscard() 
    {
        // Create a new list with the same elements (shallow copy)
        List<Card> returnList = new List<Card>(_opponentCards);

        // Clear the original list
        _opponentCards.Clear();


        return returnList;
    }
    public List<Card> GetPlayerDiscard()
    {
        // Create a new list with the same elements (shallow copy)
        List<Card> returnList;
        if(_playerCards!=null)
        { 
             returnList= new List<Card>(_playerCards);
        }
        else
        {
            returnList= new List<Card>();
        }
        return returnList;
    }
    public void UpdateDiscardContent() 
    {
        _discardPanel.SetActive(true);

        foreach (Transform card in _playerDiscardContent.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (Card card in _playerCards) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_playerDiscardContent.transform);
           cardMade.GetComponent<Card>().MakeCard(card.GetCardInfo(), false); //make an undraggable card
        }
        foreach (Card card in _opponentCards) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_opponentDiscardContent.transform);
           cardMade.GetComponent<Card>().MakeCard(card.GetCardInfo(), false); //make an undraggable card
        }
    }
}
