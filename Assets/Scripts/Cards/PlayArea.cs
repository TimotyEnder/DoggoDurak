using UnityEngine;

public class PlayArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _playAreaOffSet;
    private float _playAreaIdealOffSet;
    private float _maxHandSpacing;
    private Vector2 _playAreaAttachPos;
    private int _cardsInPlay;
    private int _playAreaSize;
    //canvas scaling
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    void Start()
    {
        _playAreaOffSet = 80;
        _playAreaIdealOffSet = 80;
        _playAreaAttachPos = new Vector2(0, 0);
        _playAreaAttachPos = new Vector2(_playAreaAttachPos.x - (this._playAreaOffSet / 2), 0);
        _canvasRect= GameObject.Find("UI").GetComponent<RectTransform>();
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
        _oldCanvasWidth= _canvasRect.rect.width;
        _maxHandSpacing = _canvasRect.rect.width * 0.6f;
    }
    void Update()
    {
        
    }
    void RealignCardsInHand()
    {
        foreach (RectTransform i in this.transform)
        {
            i.anchoredPosition = new Vector2(0, 0);
        }
        float it = 1;
        foreach (RectTransform i in this.transform)
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
        RealignCardsInHand();
        return _playAreaAttachPos;
    }
    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInPlay - 1) * this._playAreaIdealOffSet;
        return (neededWidth <= this._maxHandSpacing) ? this._playAreaIdealOffSet : (this._maxHandSpacing / (this._cardsInPlay - 1));
    }
    public int GetCardsInHand()
    {
        return this._cardsInPlay;
    }
    public int GetHandSize()
    {
        return this._playAreaSize;
    }
}
