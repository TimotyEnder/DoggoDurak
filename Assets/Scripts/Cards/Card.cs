using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDraw() 
    {
        RectTransform thisRect = this.GetComponent<RectTransform>();
        GameObject CardHolder = GameObject.Find("CardHandArea");
        CardHandArea cardHandArea = CardHolder.GetComponent<CardHandArea>();
        this.GetComponent<RectTransform>().SetParent(CardHolder.GetComponent<RectTransform>());
        thisRect.anchoredPosition = cardHandArea.Attach();

    }
}

