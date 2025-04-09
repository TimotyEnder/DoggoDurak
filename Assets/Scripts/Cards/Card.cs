using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,IDragHandler, IEndDragHandler

{
    private RectTransform _thisRect;
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


    void Start()
    {
    }
    void Awake( ) 
    {
        //card hand area
        _cardHandArea = GameObject.Find("CardHandArea");
        _cardHandAreaScript = _cardHandArea.GetComponent<CardHandArea>();
        _cardHandAreaRect = _cardHandArea.GetComponent<RectTransform>();

        //RectTransform is commonly used so we init it
        _thisRect = this.GetComponent<RectTransform>();


        //sibling index
        this._oldSiblingIndex = -1;

        //canvas
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();

        //Card Image
        _cardImage = _thisRect.Find("CardImage").gameObject;
        _cardImageRect = _cardImage.GetComponent<RectTransform>();

        //Play Area
        _playArea = GameObject.Find("PlayArea");
        _playAreaRect = _playArea.GetComponent<RectTransform>();
        _playAreaScript = _playArea.GetComponent<PlayArea>();
    }   
    // Update is called once per frame
    void Update()
    {
    }
    public void DrawCardImage(string cardChars)
    {
        Sprite cardSprite= Resources.Load<Sprite>("Grafics/Cards/" + cardChars); 
        _cardImage.GetComponent<Image>().sprite=cardSprite;
    }
    public void OnDraw() 
    {
        _played = false;
        _thisRect.SetParent(_cardHandAreaRect);
        _thisRect.anchoredPosition = _cardHandAreaScript.AttachCard();
        _thisRect.SetSiblingIndex(0);
    }
    public void OnPlay() 
    {
        _thisRect.SetParent(_playAreaRect);
        _thisRect.anchoredPosition= _playAreaScript.AttachCard();
        _thisRect.SetSiblingIndex(0);
        _thisRect.localScale = Vector3.one*0.8f;
        _cardImageRect.localScale = Vector3.one*0.8f;
        _played=true;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TopPointer(eventData)) 
        {
              _oldSiblingIndex = _thisRect.GetSiblingIndex();
              _thisRect.SetAsLastSibling();
            _cardImageRect.localScale = Vector3.one * 1.3f;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_oldSiblingIndex != -1) 
        {
            _thisRect.SetSiblingIndex(_oldSiblingIndex);
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
        _thisRect.SetParent(_canvas.gameObject.GetComponent<RectTransform>());
        _cardHandAreaScript.DettachCard();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        _thisRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        if (RectTransformUtility.RectangleContainsScreenPoint(_playAreaRect, eventData.position)) 
        {
            OnPlay();
            _isDragging = false;
        }
        else 
        {
            OnDraw();
            _isDragging = false;
        }
    }
}

