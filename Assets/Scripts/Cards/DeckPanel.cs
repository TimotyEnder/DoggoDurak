using Cysharp.Threading.Tasks;
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
    private GameObject _miscCont;
    [SerializeField]
    private GameObject _cardPrefab;
    //suit tests deck panel
    [SerializeField]
    private TextMeshProUGUI _clubsText;
    [SerializeField]
    private TextMeshProUGUI _diamondsText;
    [SerializeField]
    private TextMeshProUGUI _heartsText;
    [SerializeField]
    private TextMeshProUGUI _spadesText;
    [SerializeField]
    private TextMeshProUGUI _cardNumberText;
    //modifier tests deck panel
    [SerializeField]
    private TextMeshProUGUI _burnText;
    [SerializeField]
    private TextMeshProUGUI _bounceText;
    [SerializeField]
    private TextMeshProUGUI _crippleText;
    [SerializeField]
    private TextMeshProUGUI _drawText;
    [SerializeField]
    private TextMeshProUGUI _parryText;
    [SerializeField]
    private TextMeshProUGUI _restoringText;
    [SerializeField]
    private TextMeshProUGUI _spikyText;


    private List<CardInfo> _clubs;
    private List<CardInfo> _diamonds;
    private List<CardInfo> _hearts;
    private  List<CardInfo> _spades;   
    private List<CardInfo> _misc;
    public void Start()
    {
        //On Click config
        _deckButton.onClick.AddListener(()=> { if(!_deckPanel.activeSelf){ ShowDeck(); } else {ShrinkDeckPanel();}});
        _deckExitButton.onClick.AddListener(() => ShrinkDeckPanel());
        ClearLists();
    }
    private  void ClearLists()
    {
        _clubs=new List<CardInfo>();
        _diamonds=new List<CardInfo>();
        _hearts=new List<CardInfo>();
        _spades=new List<CardInfo>();
        _misc= new List<CardInfo>();
    }
    private async void ShrinkDeckPanel()
    {
        _deckPanel.GetComponent<Animator>().SetTrigger("Shrink");
        await UniTask.Delay(300);
        ClearLists();
        _deckPanel.SetActive(false);
    }
    public void ShowDeck() 
    {
        _deckPanel.SetActive(true);
        _deckPanel.GetComponent<Animator>().SetTrigger("Extend");

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
         foreach (Transform card in _miscCont.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (CardInfo cInfo in GameHandler.Instance.GetGameState()._deck)
        {
            PlaceInCorrectArray(cInfo);
        }
        MakeCards();
    }
    public void PlaceInCorrectArray(CardInfo c)
    {
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
            default:
                _misc.Add(c);
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
        if(_misc.Count>0)
        {
            _miscCont.SetActive(true);
            foreach(CardInfo c in _misc)
            {
                GameObject cardMade = Instantiate(_cardPrefab, _miscCont.transform);
                cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
                if(!_deck.Contains(c) && handArea!=null && !handArea.GetCards().Exists(card => card.GetCardInfo() == c))
                {
                    cardMade.GetComponent<Card>().GreyIn();
                }
            }
        }
        else
        {
            _miscCont.SetActive(false);
        }
        ComplileStatsText();
    }
    private void  ComplileStatsText()
    {
        //suit counts
        _cardNumberText.text=GameHandler.Instance.GetGameState()._deck.Count.ToString()+"\n";
        _clubsText.text="<color=white>"+_clubs.Count+"</color>"+"\n"; 
        _diamondsText.text="<color=red>"+_diamonds.Count+"</color>"+"\n";
        _heartsText.text="<color=red>"+_hearts.Count+"</color>"+"\n";
        _spadesText.text="<color=white>"+_spades.Count+"</color>"+"\n";

        //modifiers 
        _bounceText.text=CardInfo.modifierColors["Bounce"]+StylisticClass.BounceString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=>card._modifierStacks.ContainsKey("Bounce") && card._modifierStacks["Bounce"]>0).Count+"</color>"+"\n";
        _bounceText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Bounce"]+CardInfo.modifierToDescription["Bounce"]+"</color></size>");

        _burnText.text=CardInfo.modifierColors["Burn"]+StylisticClass.BurnString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Burn") && card._modifierStacks["Burn"]>0).Count+"</color>"+"\n";
        _burnText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Burn"]+CardInfo.modifierToDescription["Burn"]+"</color></size>");

        _crippleText.text=CardInfo.modifierColors["Cripple"]+StylisticClass.CrippleString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Cripple") && card._modifierStacks["Cripple"]>0).Count+"</color>"+"\n";
        _crippleText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Cripple"]+CardInfo.modifierToDescription["Cripple"]+"</color></size>");

        _drawText.text=CardInfo.modifierColors["Draw"]+StylisticClass.DrawString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Draw") && card._modifierStacks["Draw"]>0).Count+"</color>"+"\n";
        _drawText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Draw"]+CardInfo.modifierToDescription["Draw"]+"</color></size>");

        _parryText.text=CardInfo.modifierColors["Parry"]+StylisticClass.ParryString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Parry") && card._modifierStacks["Parry"]>0).Count+"</color>"+"\n";
        _parryText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Parry"]+CardInfo.modifierToDescription["Parry"]+"</color></size>");

        _restoringText.text=CardInfo.modifierColors["Restoring"]+StylisticClass.RestoringString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Restoring") && card._modifierStacks["Restoring"]>0).Count+"</color>"+"\n";
        _restoringText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Restoring"]+CardInfo.modifierToDescription["Restoring"]+"</color></size>");

        _spikyText.text=CardInfo.modifierColors["Spiky"]+StylisticClass.SpikyString+": "+GameHandler.Instance.GetGameState()._deck.FindAll(card=> card._modifierStacks.ContainsKey("Spiky") && card._modifierStacks["Spiky"]>0).Count+"</color>"+"\n";
        _spikyText.gameObject.GetComponent<ToolTip>().SetToolTipText("<size="+SettingsState.ToolTipFontSizeText+">"+CardInfo.modifierColors["Spiky"]+CardInfo.modifierToDescription["Spiky"]+"</color></size>");
    }
}
