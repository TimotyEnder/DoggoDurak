using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    [SerializeField]
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
    [SerializeField]
    private float _angleDelta = 30f;
    private float _idealAngleDelta = 30f;
    [SerializeField]
    private float radius = 150f;
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
        foreach (RectTransform i in this.transform)
        {
            i.anchoredPosition = Vector3.zero;
            i.eulerAngles = Vector3.zero;
        }
        float midpoint =(_cardsInHand-1)/2f;
        _angleDelta = GetCardSpacing();
        int index = 0;
        Vector3 center = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        foreach (RectTransform i in this.transform)
        {
            float angle = _angleDelta * (midpoint - index);
            i.transform.eulerAngles= new Vector3(0, 0, angle);
            angle *= -Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;
            i.anchoredPosition= new Vector3(center.x + x, center.y + y, 0); 
            index++;
        }
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
}
