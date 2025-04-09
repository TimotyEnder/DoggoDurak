using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _cardHolderOffSet;
    private float _cardHolderIdealOffSet;
    private float _maxHandSpacing;
    private Vector2 _cardHolderAttachPos;
    private int _cardsInHand;
    private int _handSize;
    //canvas scaling
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    void Start()
    {
        _cardHolderOffSet = 80;
        _cardHolderIdealOffSet = 80;
        _cardHolderAttachPos = new Vector2(0, 0);
        _cardHolderAttachPos = new Vector2(_cardHolderAttachPos.x - (this._cardHolderOffSet / 2), 0);
        _canvasRect= GameObject.Find("UI").GetComponent<RectTransform>();
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
        _oldCanvasWidth= _canvasRect.rect.width;
        _maxHandSpacing = _canvasRect.rect.width * 0.6f;
        Canvas.willRenderCanvases += OnCanvasWillRender;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnDestroy()
    {
        Canvas.willRenderCanvases -= OnCanvasWillRender;
    }
    public void OnCanvasWillRender() 
    {
        if (_oldCanvasWidth != _canvasRect.rect.width)
        {
            _maxHandSpacing = _canvasRect.rect.width * 0.6f;
            this._cardHolderOffSet = GetCardSpacing();
            _cardHolderAttachPos = new Vector2(-this._cardHolderOffSet / 2 + ((this._cardHolderOffSet / 2 * (_cardsInHand))), 0);
            RealignCardsInHand();
            _oldCanvasWidth = _canvasRect.rect.width;
        }
    }
    void  RealignCardsInHand() 
    {
        foreach (RectTransform i in this.transform)
        {
            i.anchoredPosition = new Vector2(0, 0);
        }
        float it = 1;
        foreach (RectTransform i in this.transform) 
        {
            i.anchoredPosition = new Vector2(_cardHolderAttachPos.x - (_cardHolderOffSet * it), 0);
            it++;
        }
    }
    public Vector2  AttachCard() 
    {
        this._cardsInHand++;
        this._cardHolderOffSet = GetCardSpacing();
        _cardHolderAttachPos = new Vector2(-this._cardHolderOffSet/2 + ((this._cardHolderOffSet/2*(_cardsInHand))), 0);
        RealignCardsInHand();
        return _cardHolderAttachPos;
    }
    public void DettachCard() 
    {
        this._cardsInHand--;
        this._cardHolderOffSet = GetCardSpacing();
        _cardHolderAttachPos = new Vector2(-this._cardHolderOffSet / 2 + ((this._cardHolderOffSet / 2 * (_cardsInHand))), 0);
        RealignCardsInHand();
    }
    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInHand - 1) * this._cardHolderIdealOffSet;
        return (neededWidth <= this._maxHandSpacing) ? this._cardHolderIdealOffSet : (this._maxHandSpacing / (this._cardsInHand - 1));
    }
    public int GetCardsInHand() 
    {
        return this._cardsInHand;
    }
    public int GetHandSize()
    {
        return this._handSize;
    }
}
