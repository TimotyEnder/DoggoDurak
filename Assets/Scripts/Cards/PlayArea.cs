using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour
{
    private float _playAreaOffSet;
    private float _playAreaIdealOffSet;
    private float _maxHandSpacing;
    private Vector2 _playAreaAttachPos;
    private int _cardsInPlay;
    private int _playAreaSize;
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    private TurnHandler _turnHandler;
    private RuleHandler _ruleHandler;
    private List<Card> _cardsPlayed;
    private List<Card> _cardsDefendedWith;
    private CardHandArea _playerHand;
    private OpponentLogic _opponentHand;
    void Start()
    {
        _cardsDefendedWith = new List<Card>();  
        _cardsPlayed = new List<Card>();    
        _playAreaOffSet = 120;
        _playAreaIdealOffSet = 120;
        _playAreaAttachPos = new Vector2(0, 0);
        _playAreaAttachPos = new Vector2(_playAreaAttachPos.x - (this._playAreaOffSet / 2), 0);
        _canvasRect= GameObject.Find("UI").GetComponent<RectTransform>();
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
        _oldCanvasWidth= _canvasRect.rect.width;
        _maxHandSpacing = _canvasRect.rect.width * 0.6f;
        _turnHandler=  GameObject.Find("TurnHandler").GetComponent<TurnHandler>(); 
        _ruleHandler= GameObject.Find("RuleHandler").GetComponent<RuleHandler>();
        _playerHand = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        _opponentHand= GameObject.Find("Opponent").GetComponent<OpponentLogic>(); 
    }
    void Update()
    {
        
    }
    public void AddtoPlayedCards(Card card) 
    {
        _cardsPlayed.Add(card); 
    }
    public void AddtoDefendedWithCards(Card card) 
    {
        _cardsDefendedWith.Add(card);
    }
    public List<Card> GetDefendedWith() 
    {
        return _cardsDefendedWith;
    }
    public List<Card> GetCardsPlayed()
    {
        return _cardsPlayed;
    }
    public
    void RealignCardsInPlay()
    {
        foreach (Card i in _cardsPlayed)
        {
            i.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        float it = 1;
        foreach (Card i in _cardsPlayed)
        {
            i.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(_playAreaAttachPos.x - (_playAreaOffSet * it), 0);
            it++;
        }
    }
    public Vector2 AttachCard()
    {
        this._cardsInPlay++;
        this._playAreaOffSet = GetCardSpacing();
        _playAreaAttachPos = new Vector2(-this._playAreaOffSet / 2 + ((this._playAreaOffSet / 2 * (_cardsInPlay))), 0);
        RealignCardsInPlay();
        return _playAreaAttachPos;
    }
    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInPlay - 1) * this._playAreaIdealOffSet;
        return (neededWidth <= this._maxHandSpacing) ? this._playAreaIdealOffSet : (this._maxHandSpacing / (this._cardsInPlay - 1));
    }
    public int GetCardsInPlay()
    {
        return this._cardsInPlay;
    }
    public int GetAreaSize()
    {
        return this._playAreaSize;
    }
    public int GetCardDefending(Vector2 screenPoint)
    {
        foreach (RectTransform child in this.transform.Find("PlayedCards")) 
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(child,screenPoint)  && !child.gameObject.GetComponent<Card>().IsDefended())
            {
                return child.GetSiblingIndex();
            }
        }
        return -1;
    }
    int UnblockedCardsAmount() 
    {
        int amount = 0;
        foreach (Card card in _cardsPlayed) 
        {
            if (!card.IsDefended()) 
            {
                amount++;
            }
        }
        return amount;
    }
    bool CanAtackWithAnotherCard() 
    {
        int unblockedCardsNum = UnblockedCardsAmount();
        if (_turnHandler.GetTurnState() == 0)
        {
            return (unblockedCardsNum < _playerHand.GetCardsInHand()+1);
        }
        else 
        {
            return (unblockedCardsNum < _opponentHand.GetCardsInHand()+1);
        }
    }
    bool CanReverseWithAnotherCard()
    {
        if (_turnHandler.GetTurnState() == 1)
        {
            return UnblockedCardsAmount() < _playerHand.GetCardsInHand();
        }
        else
        {
            return UnblockedCardsAmount() < _opponentHand.GetCardsInHand();
        }
    }
    public bool CanAttackWithCard(CardInfo card) 
    {
        if (this.transform.Find("PlayedCards").childCount == 0) { return true; }
        else if(CanAtackWithAnotherCard()) 
        {
            foreach (RectTransform child in this.transform.Find("PlayedCards")) 
            {
                if (child.gameObject.GetComponent<Card>().GetCard().getNumber() == card.getNumber()) 
                {
                    return true;
                }
            }
            foreach (RectTransform child in this.transform.Find("DefendedCards"))
            {
                if (child.gameObject.GetComponent<Card>().GetCard().getNumber() == card.getNumber())
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    public bool CardCanDefendCard(CardInfo defendingCard, CardInfo defendedCard) 
    {
        if (defendedCard.getSuit() == defendingCard.getSuit())
        {
            return defendingCard.getNumber() > defendedCard.getNumber();
        }
        else if (defendingCard.getSuit() == _ruleHandler.GetTrumpSuit()) 
        {
            return true;    
        }
        else
        {
            return false;
        }
    }
    public bool CanReverseWithCard(CardInfo card) 
    {
        if (_cardsDefendedWith.Count > 0)
        {
            return false;
        }
        else if(CanReverseWithAnotherCard())
        {
            foreach (Card cardPlayed in _cardsPlayed) 
            {
                if (card.getNumber() != cardPlayed.GetCard().getNumber()) 
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    public void Wipe() 
    {
        _cardsDefendedWith = new List<Card>();
        _cardsPlayed = new List<Card>();
        _cardsInPlay = 0;
        foreach (RectTransform child in this.transform.Find("PlayedCards"))
        {
            Destroy(child.gameObject);
        }
        foreach (RectTransform child in this.transform.Find("DefendedCards"))
        {
            Destroy(child.gameObject);
        }
    }
    public void RealignDefendingCards()
    {
        int index = 0;
        foreach (RectTransform cardTransform in this.transform.Find("PlayedCards"))
        {
            Card card= cardTransform.GetComponent<Card>();
            if (card.IsDefended()) 
            {
                Card Defendor = card.GetCardDefending();
                RectTransform defendorRect= Defendor.gameObject.GetComponent<RectTransform>();
                defendorRect.anchoredPosition= card.GetDefendPosition();
            }
        }
    }
}
