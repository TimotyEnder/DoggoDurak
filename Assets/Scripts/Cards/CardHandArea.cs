using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CardHandArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _cardHolderOffSet;
    private float _cardHolderIdealOffSet;
    [SerializeField]
    private float _maxHandSpacing;
    private Vector2 _cardHolderAttachPos;
    private int _cardsInHand;
    private int _handSize;
    void Start()
    {
        _cardHolderOffSet = 150;
        _cardHolderIdealOffSet = 150;
        _cardHolderAttachPos = new Vector2(0, 0);
        _cardHolderAttachPos = new Vector2(_cardHolderAttachPos.x - (this._cardHolderOffSet / 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void RestackHand ()
    {
        int it = 0;
        foreach (RectTransform i in this.transform)
        {
            i.SetSiblingIndex(it);
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
