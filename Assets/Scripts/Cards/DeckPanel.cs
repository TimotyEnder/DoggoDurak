using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckPanel : MonoBehaviour
{
    [SerializeField]
    private Button _deckButton;
    [SerializeField]
    private Button _deckExitButton;
    [SerializeField]
    private GameObject _deckPanel;
    [SerializeField]
    private GameObject _clubCont;
    [SerializeField]
    private GameObject _diamondCont;
    [SerializeField]
    private GameObject _heartCont;
    [SerializeField]
    private GameObject _spadeCont;
    [SerializeField]
    private GameObject _cardPrefab;

    private List<CardInfo> _clubs;
    private List<CardInfo> _diamonds;
    private List<CardInfo> _hearts;
    private  List<CardInfo> _spades;   
    public void Start()
    {
        //On Click config
        _deckButton.onClick.AddListener(UpdateDeckContent);
        _deckExitButton.onClick.AddListener(() => _deckPanel.SetActive(false));
        _clubs=new List<CardInfo>();
        _diamonds=new List<CardInfo>();
        _hearts=new List<CardInfo>();
        _spades=new List<CardInfo>();
    }
    
    public void UpdateDeckContent() 
    {
        _deckPanel.SetActive(true);

        foreach (Transform card in _clubCont.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (Transform card in _diamondCont.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (Transform card in _heartCont.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (Transform card in _spadeCont.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (CardInfo cInfo in GameHandler.Instance.GetGameState()._deck)
        {
            PlaceInCorrectArray(cInfo);
        }
        MakeCards();
        _clubs=new List<CardInfo>();
        _diamonds=new List<CardInfo>();
        _hearts=new List<CardInfo>();
        _spades=new List<CardInfo>();
    }
    public void PlaceInCorrectArray(CardInfo c)
    {
        GameObject cardMade=null;
        switch(c._suit)
        {
            case "C":
                _clubs.Add(c);  
                break;
            case "D":
                _diamonds.Add(c);
                break;
            case "H":
                _hearts.Add(c);
                break;
            case "S":
                _spades.Add(c);
                break;
        }
    }
    public void MakeCards()
    {
        _clubs.Sort((x, y) => x._number.CompareTo(y._number));
        _diamonds.Sort((x, y) => x._number.CompareTo(y._number));
        _hearts.Sort((x, y) => x._number.CompareTo(y._number));
        _spades.Sort((x, y) => x._number.CompareTo(y._number));
        foreach(CardInfo c in _clubs)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _clubCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
        }
        foreach(CardInfo c in _diamonds)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _diamondCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
        }
        foreach(CardInfo c in _hearts)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _heartCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
        }
        foreach(CardInfo c in _spades)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _spadeCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
        }
    }
}
