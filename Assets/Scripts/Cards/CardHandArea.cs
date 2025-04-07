using UnityEngine;

public class CardHandArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _cardHolderOffSet;
    private Vector2 _cardHolderAttachPos;
    private int _cardsInHand;
    private int _handSize;
    void Start()
    {
        this._cardHolderOffSet = 150;
        _cardHolderAttachPos = new Vector2(0, 0);
        _cardHolderAttachPos = new Vector2(_cardHolderAttachPos.x - (this._cardHolderOffSet / 2), 0);
    }

    // Update is called once per frame
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
            i.anchoredPosition = new Vector2(_cardHolderAttachPos.x - (_cardHolderOffSet * it), 0);
            it++;
        }
    }
    public Vector2  AttachCard() 
    {
        this._cardsInHand++;
        _cardHolderAttachPos = new Vector2(_cardHolderAttachPos.x + (this._cardHolderOffSet/2), 0);
        RealignCardsInHand();
        return _cardHolderAttachPos;
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
