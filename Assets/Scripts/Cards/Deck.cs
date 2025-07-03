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

    public void LoadDeck() 
    {
        _deck = GameHandler.Instance.GetGameState()._deck;
    }
    void Start() 
    {
        _turnHandler= GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
    }
    public void Draw() 
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
        //use for deck view i guess
        //debug 
        //GameObject.Find("PlayArea").GetComponent<PlayArea>().RealignCardsInPlay();
    }
    public IEnumerator DrawHandRoutine() 
    {
        CardHandArea cardHand= GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        int  toDraw= cardHand.GetHandSize() - cardHand.GetCardsInHand(); 
        for (int i = 0; i <toDraw; i++) 
        {
            if (_deck.Count > 0)
            {
                Draw();
            }
            else 
            {
                LoadDeck();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
