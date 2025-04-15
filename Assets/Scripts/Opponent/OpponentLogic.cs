using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class OpponentLogic : MonoBehaviour
{
    [SerializeField]
    private List<CardInfo> _hand;
    [SerializeField]
    private List<CardInfo> _deck;
    private int _handSize = 6;
    private int _life;

    private LifeTotal _lifeTotalUI;
    public OpponentHand _handUI;
    public TurnHandler _turnHandler;
    public PlayArea _playArea;
    private void Start()
    {
        _life = 40;
        _lifeTotalUI = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
        _handUI = GameObject.Find("OpponentHand").GetComponent<OpponentHand>();
        _turnHandler = GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        _playArea = GameObject.Find("PlayArea").GetComponent<PlayArea>();
        _lifeTotalUI.SetHealth(_life);
        initDeck();
        StartCoroutine(DrawHandRoutine());
    }
    public void initDeck()
    {
        _deck = new List<CardInfo>();
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
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
    bool CheckForPlays() 
    {
        //if Enemy attacking check for available attacks
        if (_turnHandler.GetTurnState() > 0)
        {
            foreach (CardInfo card in _hand)
            {
                if (_playArea.CanAttackWithCard(card))
                {
                    //attack with card
                    return true;
                }
            }
            return false;
        }
        else 
        {
            foreach (Card card in _playArea.GetCardsPlayed()) 
            {
                if (!card.IsDefended()) 
                {
                    foreach (CardInfo cardInHand in _hand) 
                    {
                        if (_playArea.CardCanDefendCard(cardInHand, card.GetCard())) 
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
    }
    void Attack() 
    {
        //choose lower card that is not trump suit and attack with it.
    }
    void Update()
    {
        
    }
    private IEnumerator DrawHandRoutine()
    {
        int toDraw = _handSize;
        for (int i = 0; i < toDraw; i++)
        {
            Draw();
            _handUI.AddCard();
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Draw()
    {
        //CardInfo handling
        int cardDrawIndex = Random.Range(0, _deck.Count);
        CardInfo cardtoDraw = _deck[cardDrawIndex];
        _deck.Remove(cardtoDraw);
        _hand.Add(cardtoDraw);
    }
    public IEnumerator EnemyPlay() 
    {
        yield return new WaitForSeconds(1);
        while (CheckForPlays()) { }
    }
}
