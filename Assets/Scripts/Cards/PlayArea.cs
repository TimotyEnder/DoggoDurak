using System.Runtime.CompilerServices;
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
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking
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
    void RealignCardsInPlay()
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
    public int GetTurnState()
    {
        return this._turnState;
    }
    public int GetCardSelected(Vector2 screenPoint)
    {
        foreach (RectTransform child in this.transform) 
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(child,screenPoint))
            {
                return child.GetSiblingIndex();
            }
        }
        return -1;
    }
}
