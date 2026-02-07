using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

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
    [SerializeField]
    TextMeshProUGUI _statsText;

    private List<CardInfo> _clubs;
    private List<CardInfo> _diamonds;
    private List<CardInfo> _hearts;
    private  List<CardInfo> _spades;   
    public void Start()
    {
        //On Click config
        _deckButton.onClick.AddListener(()=> { if(!_deckPanel.activeSelf){ UpdateDeckContent(); }});
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
        List<CardInfo> _deck= new List<CardInfo>();
        GameObject deckObj= GameObject.Find("Deck");
        if(deckObj!=null)
        {
            _deck=deckObj.GetComponent<Deck>().GetDeck();
        }
        else
        {
            _deck=GameHandler.Instance.GetGameState()._deck;
        }
        GameObject handAreaObj= GameObject.Find("CardHandArea");    
        CardHandArea handArea= handAreaObj!=null ? handAreaObj.GetComponent<CardHandArea>() : null;
        foreach(CardInfo c in _clubs)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _clubCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
            if(!_deck.Contains(c) && handArea!=null && !handArea.GetCards().Exists(card => card.GetCardInfo() == c))
            {
                cardMade.GetComponent<Card>().GreyIn();
            }
        }
        foreach(CardInfo c in _diamonds)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _diamondCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
            if(!_deck.Contains(c) && handArea!=null && !handArea.GetCards().Exists(card => card.GetCardInfo() == c))
            {
                cardMade.GetComponent<Card>().GreyIn();
            }
        }
        foreach(CardInfo c in _hearts)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _heartCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
            if(!_deck.Contains(c) && handArea!=null && !handArea.GetCards().Exists(card => card.GetCardInfo() == c))
            {
                cardMade.GetComponent<Card>().GreyIn();
            }
        }
        foreach(CardInfo c in _spades)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _spadeCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
            if(!_deck.Contains(c) && handArea!=null && !handArea.GetCards().Exists(card => card.GetCardInfo() == c))
            {
                cardMade.GetComponent<Card>().GreyIn();
            }
        }
        _statsText.text=ComplileStatsText();
    }
    private string  ComplileStatsText()
    {
        string toRet="";
        toRet+="Deck Size: "+GameHandler.Instance.GetGameState()._deck.Count+"\n";
        toRet+="<color=white>"+"Clubs: "+_clubs.Count+"</color>"+"\n"; 
        toRet+="<color=red>"+"Diamonds: "+_diamonds.Count+"</color>"+"\n";
        toRet+="<color=red>"+"Hearts: "+_hearts.Count+"</color>"+"\n";
        toRet+="<color=white>"+"Spades: "+_spades.Count+"</color>"+"\n";
        toRet+="\nModifiers in Deck:\n";
        toRet+=CardInfo.modifierColors["Bounce"]+StylisticClass.BounceString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=>card._modifierStacks.ContainsKey("Bounce") && card._modifierStacks["Bounce"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Burn"]+StylisticClass.BurnString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Burn") && card._modifierStacks["Burn"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Cripple"]+StylisticClass.CrippleString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Cripple") && card._modifierStacks["Cripple"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Draw"]+StylisticClass.DrawString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Draw") && card._modifierStacks["Draw"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Parry"]+StylisticClass.ParryString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Parry") && card._modifierStacks["Parry"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Restoring"]+StylisticClass.RestoringString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Restoring") && card._modifierStacks["Restoring"]>0).Count+"</color>"+"\n";
        toRet+=CardInfo.modifierColors["Spiky"]+StylisticClass.SpikyString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Spiky") && card._modifierStacks["Spiky"]>0).Count+"</color>"+"\n";
        return toRet;
    }
}
