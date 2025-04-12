using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    private float _cardHolderOffSet;
    private float _cardHolderIdealOffSet;
    private float _maxHandSpacing;
    private Vector2 _cardHolderAttachPos;
    [SerializeField]
    private int _cardsInHand = 0;
    [SerializeField]
    private int _handSize = 6;
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    private RectTransform _cardHandRect;
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
        //_cardHandRect = this.gameObject.GetComponent<RectTransform>();
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
    public void  RealignCardsInHand() 
    {
        foreach (RectTransform i in this.transform)
        {
            i.anchoredPosition = Vector3.zero;
            i.eulerAngles= Vector3.zero;
        }
        float it = 1;
        int index = 0;
        float fanAngle = 20f; // Total spread angle in degrees
        float startAngle = -fanAngle / 2f;
        float angleStep = fanAngle / (_cardsInHand - 1);
        Vector2 startPos = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x + ((_cardHolderOffSet * _cardsInHand)/2), 0);
        foreach (RectTransform i in this.transform) 
        {
            //rotation
            float angle = startAngle + (index * angleStep);
            i.eulerAngles = new Vector3(0, 0, angle);
            //position
            float x = startPos.x - (_cardHolderOffSet * it);
            float y = Mathf.Abs(angle) * -2f;
            i.anchoredPosition = new Vector2(x, y);
            //iterate
            index++;
            it++;
        }
    }
    public void  AttachCard() 
    {
        this._cardsInHand++;
        this._cardHolderOffSet = GetCardSpacing();
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
