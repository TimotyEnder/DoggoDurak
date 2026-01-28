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
    public void Start()
    {
        //On Click config
        _deckButton.onClick.AddListener(UpdateDeckContent);
        _deckExitButton.onClick.AddListener(() => _deckPanel.SetActive(false));
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
            GameObject cardMade = MakeAndPlace(cInfo);
            cardMade.GetComponent<Card>().MakeCard(cInfo, false); //make an undraggable card
        }
    }
    public GameObject MakeAndPlace(CardInfo c)
    {
        GameObject cardMade=null;
        switch(c._suit)
        {
            case "C":
                cardMade = Instantiate(_cardPrefab, _clubCont.transform);
                break;
            case "D":
                cardMade = Instantiate(_cardPrefab, _diamondCont.transform);
                break;
            case "H":
                cardMade = Instantiate(_cardPrefab, _heartCont.transform);
                break;
            case "S":
                cardMade = Instantiate(_cardPrefab, _spadeCont.transform);
                break;
        }
        return cardMade;
    }
}
