using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    private CardInfo _cardInfo;
    private RectTransform _cardRect;
    private GameObject _cardHandArea;
    private RectTransform _cardHandAreaRect;
    private CardHandArea _cardHandAreaScript;
    private int _oldSiblingIndex;
    private GameObject _cardImage;
    private Canvas _canvas;
    private RectTransform _cardImageRect;
    private bool _isDragging = false;
    private GameObject _playArea;
    private RectTransform _playAreaRect;
    private PlayArea _playAreaScript;
    private bool _played;
    private TurnHandler _turnHandler;
    private bool _defended;
    private Card _cardDefending;
    private OpponentLogic _opponent;


    void Start()
    {
    }
    void Awake()
    {
        //card hand area
        _cardHandArea = GameObject.Find("CardHandArea");
        _cardHandAreaScript = _cardHandArea.GetComponent<CardHandArea>();
        _cardHandAreaRect = _cardHandArea.GetComponent<RectTransform>();

        //RectTransform is commonly used so we init it
        _cardRect = this.GetComponent<RectTransform>();


        //sibling index
        this._oldSiblingIndex = -1;

        //canvas
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();

        //Card Image
        _cardImage = _cardRect.Find("CardImage").gameObject;
        _cardImageRect = _cardImage.GetComponent<RectTransform>();

        //Play Area
        _playArea = GameObject.Find("PlayArea");
        _playAreaRect = _playArea.GetComponent<RectTransform>();
        _playAreaScript = _playArea.GetComponent<PlayArea>();

        //turn handler
        _turnHandler = GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        //Defended
        _defended = false;
        //Opponent
        _opponent = GameObject.Find("Opponent").GetComponent<OpponentLogic>();
    }
    void Update()
    {
    }
    public void MakeCard(CardInfo card)
    {
        this._cardInfo = card;
        Sprite cardSprite = Resources.Load<Sprite>("Grafics/Cards/" + _cardInfo._suit + _cardInfo._number.ToString());
        _cardImage.GetComponent<Image>().sprite = cardSprite;
    }
    public void OnDraw()
    {
        _played = false;
        _cardRect.SetParent(_cardHandAreaRect);
        _cardRect.localScale = Vector3.one;
        _cardRect.SetSiblingIndex(0);
        _cardHandAreaScript.AttachCard();
        _cardHandAreaScript.AddToCards(this);
        _cardHandAreaScript.RealignCardsInHand();
    }
    public void OnPlay(Vector2 screenPoint)
    {
        int cardDefendingIndex = _playAreaScript.GetCardDefending(screenPoint);
        CardInfo cardToDefend = null;
        if (cardDefendingIndex!=-1) 
        {
            cardToDefend= _playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>().GetCard();
        }
        //playing cards  as it is your turn
        if (_turnHandler.GetTurnState() == 0 && _playAreaScript.CanAttackWithCard(this.GetCard()))
        {
            PlayCard();
            StartCoroutine(_opponent.EnemyPlay());
        }
        //Defending, not your turn
        else if (_turnHandler.GetTurnState() != 0 && cardDefendingIndex != -1 && _playAreaScript.CardCanDefendCard(this.GetCard(), cardToDefend))
        {
            DefendCard(_playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>());
            StartCoroutine(_opponent.EnemyPlay());
        }
        //reverse
        else if (_playAreaScript.CanReverseWithCard(this._cardInfo)) 
        {
            PlayCard();
            _cardInfo.OnReverse(this);
            _turnHandler.Reverse();
            StartCoroutine(_opponent.EnemyPlay());
        }
        else
        {
            OnDraw();
        }
    }
    public void PlayCard() 
    {
        _cardRect.SetParent(_playAreaRect.transform.Find("PlayedCards"));
        _cardRect.localScale = Vector3.one * 0.9f;
        _cardImageRect.localScale = Vector3.one * 0.9f;
        _playAreaScript.AddtoPlayedCards(this);
        _playAreaScript.AttachCard();
        _played = true;
        _cardInfo.OnPlayedCard(this);
    }
    public void DefendCard(Card card) 
    {
        _cardRect.SetParent(_playAreaRect.transform.Find("DefendedCards"));
        _cardRect.SetAsFirstSibling();
        _cardRect.localScale = Vector3.one * 0.9f;
        _cardImageRect.localScale = Vector3.one * 0.9f;
        _cardRect.anchoredPosition = card.GetDefendPosition();//hehe
        card.Defend(this);
        _playAreaScript.AddtoDefendedWithCards(this);
        _played = true;
        _cardInfo.OnDefendCard(this, card);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TopPointer(eventData))
        {
            _oldSiblingIndex = _cardRect.GetSiblingIndex();
            _cardRect.SetAsLastSibling();
            _cardImageRect.localScale = Vector3.one * 1.3f;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_oldSiblingIndex != -1)
        {
            _cardRect.SetSiblingIndex(_oldSiblingIndex);
        }
        _cardImageRect.localScale = Vector3.one;
    }
    private bool TopPointer(PointerEventData ped)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Card>() != null)
            {
                if (result.gameObject == this.gameObject)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        _isDragging = true;
        _cardRect.SetParent(_canvas.gameObject.GetComponent<RectTransform>());
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        _cardRect.eulerAngles = Vector3.zero;
        _cardRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        if (RectTransformUtility.RectangleContainsScreenPoint(_playAreaRect, eventData.position))
        {
            _cardHandAreaScript.RemoveFromCards(this);
            _cardHandAreaScript.DettachCard();
            OnPlay(eventData.position);
            _isDragging = false;
        }
        else
        {
            OnDraw();
            _isDragging = false;
        }
    }
    public Vector2 GetDefendPosition()
    {
        return new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y - (this.GetComponent<RectTransform>().rect.height*0.5f));
    }
    public CardInfo GetCard()
    {
        return this._cardInfo;
    }
    public void Defend(Card defendedWith) 
    {
        _defended = true;  
        _cardDefending = defendedWith;
        _cardInfo.OnBeingDefended(defendedWith);
    }
    public Card GetCardDefending() 
    {
        return _cardDefending;
    }
    public bool IsDefended() 
    {
        return _defended;   
    }
}

