using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Deck : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject _card;
    [SerializeField]
    private List<CardInfo> _deck;
    void Start()
    {
        initDeck();
    }
    void initDeck() 
    {
        _deck = new List<CardInfo>();
        for(int i=0;i<4;i++) 
        {
            switch(i) {
            case 0:
                    for (int j = 6; j < 15; j++) 
                    {
                        _deck.Add(new CardInfo("C", j));
                    }
                    break;
            case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("S", j));
                    }
                    break;
            case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("D", j));
                    }
                    break;
            case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("H", j));
                    }
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Draw() 
    {
        //CardInfo handling
        int cardDrawIndex = Random.Range(0, _deck.Count);
        CardInfo cardtoDraw= _deck[cardDrawIndex];
        _deck.Remove(cardtoDraw);

        //Card Visual Handling
        GameObject CardDrawn = Instantiate(_card);
        CardDrawn.GetComponent<Card>().MakeCard(cardtoDraw);
        CardDrawn.GetComponent<Card>().OnDraw();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Draw();
    }
}
