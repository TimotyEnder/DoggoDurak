using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Discard : MonoBehaviour
{
    List<CardInfo> _playerCards;
    List<CardInfo> _opponentCards;
    [SerializeField]
    private Button _discardButton;
    [SerializeField]
    private Button _discardExitButton;
    [SerializeField]
    private GameObject _discardPanel;
    [SerializeField]
    private GameObject _discardContent;
    [SerializeField]
    private GameObject _cardPrefab;
    public void Start()
    {
        _opponentCards = new List<CardInfo>();
        _playerCards = new List<CardInfo>();
        //On Click config
        _discardButton.onClick.AddListener(UpdateDiscardContent);
        _discardExitButton.onClick.AddListener(() => _discardPanel.SetActive(false));
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
    public void UpdateDiscardContent() 
    {
        _discardPanel.SetActive(true);

        foreach (Transform card in _discardContent.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (CardInfo cInfo in _playerCards) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_discardContent.transform);
           cardMade.GetComponent<Card>().MakeCard(cInfo, false); //make an undraggable card
        }
    }
}
