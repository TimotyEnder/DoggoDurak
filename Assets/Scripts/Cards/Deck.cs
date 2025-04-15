using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;


public class Deck : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject _card;
    [SerializeField]
    private List<CardInfo> _deck;

    private TurnHandler _turnHandler;

    public void initDeck() 
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
    void Start() 
    {
        _turnHandler= GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        initDeck();
        DrawHand();
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
    public void DrawHand()
    {
          StartCoroutine(DrawHandRoutine());      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //maybe  show deck remaining on click idk
    }
    private IEnumerator DrawHandRoutine() 
    {
        CardHandArea cardHand= GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        int  toDraw= cardHand.GetHandSize() - cardHand.GetCardsInHand(); 
        for (int i = 0; i <toDraw; i++) 
        {
            Draw();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
