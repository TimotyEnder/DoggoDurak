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
    public
    void RealignCardsInPlay()
    {
        foreach (RectTransform i in this.transform.Find("PlayedCards"))
        {
            i.anchoredPosition = new Vector2(0, 0);
        }
        float it = 1;
        foreach (RectTransform i in this.transform.Find("PlayedCards"))
        {
            i.anchoredPosition = new Vector2(_playAreaAttachPos.x - (_playAreaOffSet * it), 0);
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
    public bool CanAttackWithCard(CardInfo card) 
    {
        if (this.transform.Find("PlayedCards").childCount == 0) { return true; }
        else 
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
}
