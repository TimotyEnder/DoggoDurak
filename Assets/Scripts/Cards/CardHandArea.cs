using UnityEngine;

public class CardHandArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float _cardHolderOffSet = 1.0f;
    private Vector2 _cardHolderAttachPos;
    void Start()
    {
        _cardHolderAttachPos = this.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shift() 
    {
        foreach (RectTransform i in this.transform) 
        {
            i.anchoredPosition = new Vector2(i.anchoredPosition.x-this._cardHolderOffSet, i.anchoredPosition.y);
        }
    }
    public Vector2  Attach() 
    {
        shift();
        _cardHolderAttachPos = new Vector2(_cardHolderAttachPos.x - _cardHolderOffSet, _cardHolderAttachPos.y);
        return _cardHolderAttachPos;
    }
}
