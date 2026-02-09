using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    [SerializeField]
    private float _maxHandSpacing;
    [SerializeField]
    private int _cardsInHand = 0;
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    private RectTransform _cardHandRect;
    [SerializeField]
    private float _angleDelta;
    [SerializeField]
    private float _idealAngleDelta;
    [SerializeField]
    private float radius;
    [SerializeField]
    private List<Card> _cards;
    void Start()
    {
        _canvasRect= GameObject.Find("UI").GetComponent<RectTransform>();
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
        _oldCanvasWidth= _canvasRect.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void RealignCardsInHand()
    {
        foreach (Card i in _cards)
        {
            i.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            i.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
        }
        float midpoint =(_cardsInHand-1)/2f;
        _angleDelta = GetCardSpacing();
        int index = 0;
        Vector3 center = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        foreach (Card i in _cards)
        {
            float angle = _angleDelta * (midpoint - index);
            i.transform.eulerAngles= new Vector3(0, 0, angle);
            angle *= -Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;
            i.GetComponent<RectTransform>().anchoredPosition= new Vector3(center.x + x, center.y + y, 0); 
            index++;
        }
    }
    public List<Card> GetCards() 
    {
        return this._cards;
    }   
    public void OrderByRank()
    {
        _cards.Sort((a, b) => (a.GetCardInfo()._number == b.GetCardInfo()._number) ? a.GetCardInfo()._suitNumber.CompareTo(b.GetCardInfo()._suitNumber):a.GetCardInfo()._number.CompareTo(b.GetCardInfo()._number));
        RealignCardsInHand();
    }
    public void OrderBySuit()
    {
        _cards.Sort((a, b) => a.GetCardInfo()._suitNumber.CompareTo(b.GetCardInfo()._suitNumber));
        RealignCardsInHand();
    }
    public void  AttachCard() 
    {
        this._cardsInHand++;
    }
    public void DettachCard() 
    {
        this._cardsInHand--;
        RealignCardsInHand();
    }
    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInHand - 1) * this._idealAngleDelta;
        return (neededWidth <= this._maxHandSpacing) ? this._idealAngleDelta : (this._maxHandSpacing / (this._cardsInHand - 1));
    }
    public int GetCardsInHand() 
    {
        return this._cardsInHand;
    }
    public void AddToCards(Card card) 
    {
        if (_cards == null) 
        {
            _cards = new List<Card>();
        }
        _cards.Add(card);
    }
    public void RemoveFromCards(Card card)
    {
        if (_cards == null)
        {
            _cards = new List<Card>();
        }
        _cards.Remove(card); 
    }
    public void GreyOutAllCards() 
    {
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card")) 
        {
            card.GetComponent<Card>().GreyOut();
        }
    }
    public void GreyInAllCards()
    {
        foreach (Card card in this._cards)
        {
            card.GreyIn();
        }
    }
    public bool HasMorePlays() 
    {
        PlayArea pa= GameObject.Find("PlayArea").GetComponent<PlayArea>();
        TurnHandler th= GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        Debug.Log("automatic turn end checking!");
        if (pa != null)
        {
            foreach (Card card in this._cards)
            {
                Debug.Log("Concidering Card: "+ card.GetCardInfo()._suit+ card.GetCardInfo()._number);
                if ((pa.CanReverseWithCard(card.GetCardInfo()) || pa.CanAttackWithCard(card.GetCardInfo())) && th.GetTurnState() == 0)
                {
                    Debug.Log("Can Reverse Or Attack With Card");
                    return true;
                }
                if (th.GetTurnState() != 0)
                {
                    bool allDefended = true; //check if all card have been defended
                    foreach (Card pcard in pa.GetCardsPlayed())
                    {
                        if (!pcard.IsDefended())
                        {
                            allDefended = false;
                        }
                    }
                    if (allDefended)
                    {
                        Debug.Log("All Defended");
                        return false;
                    }
                    foreach (Card pcard in pa.GetCardsPlayed())
                    {
                        if (pa.CardCanDefendCard(card.GetCardInfo(), pcard.GetCardInfo()) && !pcard.IsDefended())
                        {
                            Debug.Log("Current Card "+card.GetCardInfo()+"Can Defend: "+pcard.GetCardInfo());
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
