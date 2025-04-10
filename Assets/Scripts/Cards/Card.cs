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
    }
    void Update()
    {
    }
    public void MakeCard(CardInfo card)
    {
        this._cardInfo = card;
        Sprite cardSprite = Resources.Load<Sprite>("Grafics/Cards/" + _cardInfo.getSuit() + _cardInfo.getNumber().ToString());
        _cardImage.GetComponent<Image>().sprite = cardSprite;
    }
    public void OnDraw()
    {
        _played = false;
        _cardRect.SetParent(_cardHandAreaRect);
        _cardRect.anchoredPosition = _cardHandAreaScript.AttachCard();
        _cardRect.SetSiblingIndex(0);
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
            _cardRect.SetParent(_playAreaRect.transform.Find("PlayedCards"));
            _cardRect.anchoredPosition = _playAreaScript.AttachCard();
            _cardRect.SetSiblingIndex(0);
            _cardRect.localScale = Vector3.one * 0.8f;
            _cardImageRect.localScale = Vector3.one * 0.8f;
            _played = true;
        }
        //Defending, not your turn
        else if (_turnHandler.GetTurnState() != 0 && cardDefendingIndex != -1 && _playAreaScript.CardCanDefendCard(this.GetCard(), cardToDefend))
        {
            _cardRect.anchoredPosition = _playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>().GetDefendPosition();//hehe
            _playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>().Defend();
            _cardRect.SetParent(_playAreaRect.transform.Find("DefendedCards"));
            _cardRect.SetAsFirstSibling();
            _cardRect.localScale = Vector3.one * 0.8f;
            _cardImageRect.localScale = Vector3.one * 0.8f;
            _played = true;
        }
        else
        {
            OnDraw();
        }
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
        _cardHandAreaScript.DettachCard();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        _cardRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        if (RectTransformUtility.RectangleContainsScreenPoint(_playAreaRect, eventData.position))
        {
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
        return new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y - 20f);
    }
    public CardInfo GetCard()
    {
        return this._cardInfo;
    }
    public void Defend() 
    {
        this._defended = true;  
    }
    public bool IsDefended() 
    {
        return _defended;   
    }
}

