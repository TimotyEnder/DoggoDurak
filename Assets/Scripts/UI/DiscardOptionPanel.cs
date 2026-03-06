using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DiscardOptionPanel : MonoBehaviour
{
    [SerializeField]
    private Button _disButton;
    [SerializeField]
    private Button _disExitButton;
    [SerializeField]
    private Button _disConfirmButton;
    [SerializeField]
    private TextMeshProUGUI _disConfText;
    [SerializeField]
    private GameObject _disPanel;
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

  
    private List<Card> _cardsSelected;
    private int _totalDiscardCost;
    private Animator _disPanelAnim;
    public void Start()
    {
        //On Click config
        _disButton.onClick.AddListener(() => ShowDeckContent());
        _disExitButton.onClick.AddListener(() => DisPanelCloseHandler());
        _disConfirmButton.onClick.AddListener(()=>DisConfHandler());
        _disPanelAnim=_disPanel.GetComponent<Animator>();
        UpdateCostText();
    }
    private async void DisConfHandler()
    {
        if(GameHandler.Instance.GetGameState()._rubles>=_totalDiscardCost)
        {
            foreach(Card c in  _cardsSelected)
            {
                GameHandler.Instance.GetGameState()._deck.Remove(c.GetCardInfo());
                c.Bling();
            }
            GameHandler.Instance.UpdateMoney(-_totalDiscardCost);
            await UniTask.Delay(300);
            _totalDiscardCost=0;
            UpdateCostText();
            UpdateDeckContent();
        }
        else
        {
            Color oldColor= _disConfText.color;
            _disConfText.color=Color.red;
            await UniTask.Delay(200);
            _disConfText.color=oldColor;
        }
    }
    private async void DisPanelCloseHandler()
    {
        List<Card> cardToUnselect=new List<Card>();
        foreach(Card c in _cardsSelected)
        {
            cardToUnselect.Add(c);
            c.Unmark();
        }
        foreach(Card c in cardToUnselect)
        {
            UnSelectCard(c);
        }
        _disPanelAnim.SetTrigger("Shrink");
        await UniTask.Delay(300);
        _disPanel.SetActive(false);
    }
    private void ShowDeckContent()
    {
        _disPanel.SetActive(true);
        _disPanelAnim.SetTrigger("Extend");
        UpdateDeckContent();
    }
    public void UpdateDeckContent()
    {
        _clubs=new List<CardInfo>();
        _diamonds=new List<CardInfo>();
        _hearts=new List<CardInfo>();
        _spades=new List<CardInfo>();
        _cardsSelected= new List<Card>();
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
           // GameObject cardMade = Instantiate(_cardPrefab, _disContent.transform);
            //cardMade.GetComponent<Card>().MakeCard(cInfo, false); //make an undraggable card
        }
        foreach(CardInfo c in _clubs)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _clubCont.transform);
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
        foreach(CardInfo c in _diamonds)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _diamondCont.transform);
            cardMade.GetComponent<Card>().MakeCard(c, false); //make an undraggable card
        }
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
        }
    }
    public void SelectCard(Card Card)
    {
        _cardsSelected.Add(Card);
        _totalDiscardCost+=GameHandler.Instance.GetGameState()._discardingCardInShopCost;
        GameHandler.Instance.GetGameState()._discardingCardInShopCost++;
        UpdateCostText();
    }
    public void UnSelectCard(Card Card)
    {
        _cardsSelected.Remove(Card);
        GameHandler.Instance.GetGameState()._discardingCardInShopCost--;
        _totalDiscardCost-=GameHandler.Instance.GetGameState()._discardingCardInShopCost;
        UpdateCostText();
    }
    public void UpdateCostText()
    {
        _disConfText.text=$"({_totalDiscardCost}{_disConfText.text.Substring(_disConfText.text.Count()-2)}";
    }
}
