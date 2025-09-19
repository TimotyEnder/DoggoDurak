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
    private GameObject _deckContent;
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

        foreach (Transform card in _deckContent.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (CardInfo cInfo in GameHandler.Instance.GetGameState()._deck) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_deckContent.transform);
           cardMade.GetComponent<Card>().MakeCard(cInfo, false); //make an undraggable card
        }
    }
}
