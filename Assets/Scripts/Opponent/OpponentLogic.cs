using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class OpponentLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject cardMaker;
    [SerializeField]
    private List<CardInfo> _hand;
    [SerializeField]
    private List<CardInfo> _deck;
    private int _handSize = 6;

    private LifeTotal _lifeTotalUI;
    private OpponentHand _handUI;
    private TurnHandler _turnHandler;
    private PlayArea _playArea;
    private RuleHandler _ruleHandler;

    private bool endTurnCaused = false;//flag to stop end turn infinite loop 
    private bool _enemyPlaying = false;
    private CardHandArea _cardHandArea;

    private Discard _discard;
    private void Start()
    {
        _lifeTotalUI = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
        _handUI = GameObject.Find("OpponentHand").GetComponent<OpponentHand>();
        _turnHandler = GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        _playArea = GameObject.Find("PlayArea").GetComponent<PlayArea>();
        _ruleHandler = GameObject.Find("RuleHandler").GetComponent<RuleHandler>();
        _discard = GameObject.Find("Discard").GetComponent<Discard>();
        _cardHandArea = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        LoadDeck();
    }
    public int GetCardsInHand()
    {
        return _hand.Count;
    }
    public bool IsEnemyPlaying() 
    {
        return _enemyPlaying;
    }
    public void LoadDeck()
    {
        _deck = new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetCurrEncounter().GetDeck())
        {
            _deck.Add(c);
        }
    }
    public void LoadDiscard()
    {
        _deck = _discard.GetOpponentDiscard();
    }
    //check once for available plays
    bool CheckPlay() 
    {
        //if Enemy attacking check for available attacks
        if (_turnHandler.GetTurnState() > 0)
        {
            foreach (CardInfo cardInHand in _hand)
            {
                if (_playArea.CanAttackWithCard(cardInHand))
                {
                    _hand.Remove(cardInHand);
                    _handUI.RemoveCard();
                    GameObject CardToAttack = Instantiate(cardMaker);
                    CardToAttack.GetComponent<Card>().MakeCard(cardInHand);
                    CardToAttack.GetComponent<Card>().PlayCard();
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
                    CardInfo smallestCardThatDefends = null;
                    foreach (CardInfo cardInHand in _hand)
                    {
                        //reverse if possible
                        if (_playArea.CanReverseWithCard(cardInHand))
                        {
                            _hand.Remove(cardInHand);
                            _handUI.RemoveCard();
                            GameObject CardToReverse = Instantiate(cardMaker);
                            CardToReverse.GetComponent<Card>().MakeCard(cardInHand);
                            CardToReverse.GetComponent<Card>().PlayCard();
                            CardToReverse.GetComponent<Card>().GetCardInfo().OnReverse(CardToReverse.GetComponent<Card>());
                            GameHandler.Instance.GetGameState().OnReverse(CardToReverse.GetComponent<Card>());
                            _turnHandler.Reverse();
                            return true;
                        }
                        //Defending if cannot reverse
                        else if (_playArea.CardCanDefendCard(cardInHand, card.GetCardInfo()))
                        {
                            if (smallestCardThatDefends == null)
                            {
                                smallestCardThatDefends = cardInHand;
                            }
                            else if (smallestCardThatDefends._number > cardInHand._number)
                            {
                                smallestCardThatDefends = cardInHand;
                            }
                        }
                    }
                    if (smallestCardThatDefends != null)
                    {
                        _hand.Remove(smallestCardThatDefends);
                        _handUI.RemoveCard();
                        GameObject CardToDefend = Instantiate(cardMaker);
                        CardToDefend.GetComponent<Card>().MakeCard(smallestCardThatDefends);
                        CardToDefend.GetComponent<Card>().DefendCard(card);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
    public void Attack() 
    {
        CardInfo lowerCard = _hand[0];
        foreach(CardInfo card in _hand) 
        {
            if (lowerCard._suit == _ruleHandler.GetTrumpSuit() && card._suit != _ruleHandler.GetTrumpSuit())
            {
                lowerCard = card;
            }
            else if (card._number < lowerCard._number) 
            {
                lowerCard = card;
            }
        }
        GameObject CardToAttack = Instantiate(cardMaker);
        CardToAttack.GetComponent<Card>().MakeCard(lowerCard);
        CardToAttack.GetComponent<Card>().PlayCard();
    }
    void Update()
    {
        
    }
    public  IEnumerator DrawHandRoutine()
    {
        int toDraw = _handSize-_hand.Count;
        for (int i = 0; i < toDraw; i++)
        {
            if (_deck.Count > 0)
            {
                Draw();
                _handUI.AddCard();
            }
            else 
            {
                LoadDiscard();
                Draw();
                _handUI.AddCard();
            }
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
    public void Discard() 
    {
        if (_hand.Count>0) 
        {
            int RandomIndex = Random.Range(0, _hand.Count);
            _discard.AddCard(_deck[RandomIndex]); //add to discard pile if a card is discarded
            _hand.RemoveAt(RandomIndex);
            _handUI.RemoveCard();
        }
    }
    public IEnumerator EnemyPlay() 
    {
        _enemyPlaying = true;
        _cardHandArea.GreyInAllCards();
        yield return new WaitForEndOfFrame();
        StartCoroutine(CheckForPlaysRoutine());
    }
    
    public IEnumerator CheckForPlaysRoutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);  
        while (CheckPlay()) 
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Enemy Turn Routine!");
        CardHandArea cha = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        if (!endTurnCaused && cha != null && !cha.HasMorePlays()) 
        {
            endTurnCaused = true;
            _turnHandler.StartEndTurn();
        }
        _enemyPlaying = false;
        _cardHandArea.GreyOutAllCards();
    }
    public void resetEndTunFlag() 
    {
        endTurnCaused = false;
    }
}
