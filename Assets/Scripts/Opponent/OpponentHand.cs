using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : MonoBehaviour
{
    [SerializeField]
    private float _maxHandSpacing;
    [SerializeField]
    private GameObject _opCard;
    [SerializeField]
    private float _angleDelta = 30f;
    private float _idealAngleDelta = 30f;
    [SerializeField]
    private float radius = 150f;
    private int _cardsInHand;
    private RectTransform _canvas;
    private List<GameObject> _cards = new List<GameObject>(); // Track cards manually
    void Start()
    {
        _canvas= GameObject.Find("UI").GetComponent<RectTransform>();   
    }
    void Update()
    {
        
    }
    public void AddCard()
    {
        GameObject card = Instantiate(_opCard, this.transform);
        _cards.Add(card); // Add to list
        _cardsInHand++;
        RealignCardsInHand();
    }

    public void RemoveCard()
    {
        if (_cards.Count == 0) return; // No cards left
        GameObject cardToRemove = _cards[0];
        _cards.RemoveAt(0);
        cardToRemove.transform.SetParent(null);
        if (cardToRemove != null)
            Destroy(cardToRemove); // Safe destroy

        _cardsInHand--;
        StartCoroutine(DelayedRealign()); // Wait for destruction
    }
    public void RealignCardsInHand()
    {
        foreach (RectTransform i in this.transform)
        {
            i.anchoredPosition = Vector3.zero;
            i.eulerAngles = Vector3.zero;
        }
        float midpoint = (_cardsInHand - 1) / 2f;
        _angleDelta = GetCardSpacing();
        int index = 0;
        Vector3 center = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        foreach (RectTransform i in this.transform)
        {
            float angle = _angleDelta * (midpoint - index);
            i.transform.eulerAngles = new Vector3(0, 0, angle);
            angle *= -Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;
            i.anchoredPosition = new Vector3(center.x + x, center.y + y, 0);
            index++;
        }
    }
    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInHand - 1) * this._idealAngleDelta;
        return (neededWidth <= this._maxHandSpacing) ? this._idealAngleDelta : (this._maxHandSpacing / (this._cardsInHand - 1));
    }
    private IEnumerator DelayedRealign()
    {
        yield return new WaitForEndOfFrame(); // Ensure object is destroyed
        RealignCardsInHand();
    }
}
