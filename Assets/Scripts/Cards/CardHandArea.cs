using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    [SerializeField]
    private float _maxHandSpacing;
    [SerializeField]
    private int _cardsInHand = 0;
    [SerializeField]
    private int _handSize = 6;
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    private RectTransform _cardHandRect;
    [SerializeField]
    private float _angleDelta = 25f;
    private float _idealAngleDelta = 25f;
    [SerializeField]
    private float radius = 200f;
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
    public void OrderByRank()
    {
        _cards.Sort((a, b) => (a.GetCard().getNumber()==b.GetCard().getNumber())? a.GetCard().getSuitNumber().CompareTo(b.GetCard().getSuitNumber()):a.GetCard().getNumber().CompareTo(b.GetCard().getNumber()));
        RealignCardsInHand();
    }
    public void OrderBySuit()
    {
        _cards.Sort((a, b) => a.GetCard().getSuitNumber().CompareTo(b.GetCard().getSuitNumber()));
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
    public int GetHandSize()
    {
        return this._handSize;
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
}
