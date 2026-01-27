using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using System;


public class Deck : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject _card;
    [SerializeField]
    private List<CardInfo> _deck;

    private TurnHandler _turnHandler;
    private Discard _discard;
    [SerializeField]
    private GameObject cardDrawParticlePrefab;

   
    void Start() 
    {
        _turnHandler= GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        _discard = GameObject.Find("Discard").GetComponent<Discard>();
    }
    public void LoadDeck()
    {
        _deck = new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            _deck.Add(c);
        }
    }
    public void LoadDiscard()
    {
        _deck = new List<CardInfo>();
        foreach(Card c in _discard.GetPlayerDiscard())
        {
            _deck.Add(c.GetCardInfo());
        }
    }
    public void Draw() 
    {
        // CardInfo handling
        int cardDrawIndex = UnityEngine.Random.Range(0, _deck.Count);
        CardInfo cardtoDraw = _deck[cardDrawIndex];
        _deck.Remove(cardtoDraw);

        // Card draw particle with callback
        RectTransform target = GameObject.Find("DrawToHere").GetComponent<RectTransform>();
        StartCoroutine(DrawParticleRoutine(target, () => 
        {
            // This callback runs after the coroutine completes
            OnDrawParticleComplete(cardtoDraw);
        }));
    }

    private void OnDrawParticleComplete(CardInfo cardtoDraw)
    {
        // Card Visual Handling
        GameObject CardDrawn = Instantiate(_card);
        CardDrawn.GetComponent<Card>().MakeCard(cardtoDraw);
        CardDrawn.GetComponent<Card>().OnDraw();
    }
    private IEnumerator DrawParticleRoutine(RectTransform target, Action onComplete)
    {
        GameObject particle = Instantiate(cardDrawParticlePrefab, this.transform.position, Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Canvas").transform);
        CardDrawParticle particleScript = particle.GetComponent<CardDrawParticle>();
        particleScript.SetTarget(target);
        while (particle != null)
        {
            yield return null;
        }
        onComplete?.Invoke();
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
        int  toDraw= GameHandler.Instance.GetGameState()._handSize - cardHand.GetCardsInHand(); 
        for (int i = 0; i <toDraw; i++) 
        {
            if (_deck.Count > 0)
            {
                Draw();
            }
            else 
            {
                LoadDiscard();
                Draw();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
