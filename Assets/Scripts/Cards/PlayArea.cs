using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    private float _playAreaOffSet;
    private float _playAreaIdealOffSet;
    private float _maxHandSpacing;
    private Vector2 _playAreaAttachPos;
    private int _cardsInPlay;
    private int _playAreaSize = 0;
    private RectTransform _canvasRect;
    private Canvas _canvas;
    private float _oldCanvasWidth;
    private TurnHandler _turnHandler;
    private RuleHandler _ruleHandler;

    [SerializeField]
    private List<Card> _cardsPlayed;
    private List<Card> _cardsDefendedWith;
    private CardHandArea _playerHand;
    private OpponentLogic _opponentHand;
    private Discard _discard;
    private ResponseText _responseText;

    void Awake()
    {
        _cardsDefendedWith = new List<Card>();
        _cardsPlayed = new List<Card>();
        _playAreaOffSet = 120;
        _playAreaIdealOffSet = 120;
        _playAreaAttachPos = new Vector2(0, 0);
        _playAreaAttachPos = new Vector2(_playAreaAttachPos.x - (this._playAreaOffSet / 2), 0);
        _canvasRect = GameObject.Find("UI").GetComponent<RectTransform>();
        _canvas = GameObject.Find("UI").GetComponent<Canvas>();
        _oldCanvasWidth = _canvasRect.rect.width;
        _maxHandSpacing = _canvasRect.rect.width * 0.6f;
        _turnHandler = GameObject.Find("TurnHandler")?.GetComponent<TurnHandler>();
        _ruleHandler = GameObject.Find("RuleHandler")?.GetComponent<RuleHandler>();
        _playerHand = GameObject.Find("CardHandArea")?.GetComponent<CardHandArea>();
        _opponentHand = GameObject.Find("Opponent")?.GetComponent<OpponentLogic>();
        _discard = GameObject.Find("Discard")?.GetComponent<Discard>();
        _responseText = GameObject.Find("ResponseText")?.GetComponent<ResponseText>();
    }

    void Update() { }

    public void AddtoPlayedCards(Card card)
    {
        _cardsPlayed.Insert(0, card);
    }

    public void AddtoDefendedWithCards(Card card)
    {
        _cardsDefendedWith.Add(card);
    }

    public List<Card> GetDefendedWith()
    {
        return _cardsDefendedWith;
    }

    public List<Card> GetCardsPlayed()
    {
        return _cardsPlayed;
    }

    public void RealignCardsInPlay()
    {
        Vector2 initPosition = new Vector2(((_cardsPlayed.Count + 1) * _playAreaOffSet) / 2, 0);
        foreach (Card i in _cardsPlayed)
        {
            i.gameObject.GetComponent<RectTransform>().anchoredPosition = initPosition;
        }
        float it = 1;
        foreach (Card i in _cardsPlayed)
        {
            i.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                initPosition.x - (_playAreaOffSet * it),
                0
            );
            it++;
            if (!i.IsDefended())
            {
                i.UpdateCardArrows();
            }
        }
        RealignDefendingCards();
    }

    public void AttachCard()
    {
        this._cardsInPlay++;
        this._playAreaOffSet = GetCardSpacing();
        RealignCardsInPlay();
    }

    float GetCardSpacing()
    {
        float neededWidth = (this._cardsInPlay - 1) * this._playAreaIdealOffSet;
        return (neededWidth <= this._maxHandSpacing)
            ? this._playAreaIdealOffSet
            : (this._maxHandSpacing / (this._cardsInPlay - 1));
    }

    public int GetCardsInPlay()
    {
        return this._cardsInPlay;
    }

    public int GetAreaSize()
    {
        return this._playAreaSize;
    }

    public int GetCardDefending(Vector2 screenPoint)
    {
        foreach (RectTransform child in this.transform.Find("PlayedCards"))
        {
            if (
                RectTransformUtility.RectangleContainsScreenPoint(child, screenPoint)
                && !child.gameObject.GetComponent<Card>().IsDefended()
            )
            {
                return child.GetSiblingIndex();
            }
        }
        return -1;
    }

    public int GetNumCardsBlocking()
    {
        return this.transform.Find("DefendedCards").childCount;
    }

    public int UnblockedCardsAmount()
    {
        int amount = 0;
        foreach (Card card in _cardsPlayed)
        {
            if (!card.IsDefended())
            {
                amount++;
            }
        }
        return amount;
    }

    bool CanAtackWithAnotherCard()
    {
        int unblockedCardsNum = UnblockedCardsAmount();
        if (_turnHandler.GetTurnState() == 1)
        {
            return (unblockedCardsNum + 1 <= _playerHand.GetCardsInHand());
        }
        else
        {
            return true;
            //return (unblockedCardsNum + 1 <= _opponentHand.GetCardsInHand());
        }
    }

    bool CanReverseWithAnotherCard()
    {
        if (_turnHandler.GetTurnState() == 0)
        {
            return UnblockedCardsAmount() <= _playerHand.GetCardsInHand();
        }
        else
        {
            return true;
            // UnblockedCardsAmount() < _opponentHand.GetCardsInHand();
        }
    }

    public bool CanAttackWithCard(CardInfo card, bool ShowErrorResponses = false)
    {
        if (this.transform.Find("PlayedCards").childCount == 0)
        {
            return true;
        }
        else if (CanAtackWithAnotherCard())
        {
            foreach (RectTransform child in this.transform.Find("PlayedCards"))
            {
                if (child.gameObject.GetComponent<Card>().GetCardInfo()._number == card._number)
                {
                    return true;
                }
            }
            foreach (RectTransform child in this.transform.Find("DefendedCards"))
            {
                if (child.gameObject.GetComponent<Card>().GetCardInfo()._number == card._number)
                {
                    return true;
                }
            }
            if (ShowErrorResponses)
            {
                _responseText?.AddToResponseText(
                    $"Cannot Attack with this card because it does not share its number with any other card!"
                );
            }
        }
        else
        {
            if (ShowErrorResponses)
            {
                _responseText.AddToResponseText($"Cannot Attack with any more cards!");
            }
        }
        return false;
    }

    public bool CardCanDefendCard(
        CardInfo defendingCard,
        CardInfo defendedCard,
        bool ShowErrorResponses = false
    )
    {
        if (
            defendedCard._opponentCard
            && GameHandler.Instance.GetGameState()._blackCardsSameSuit
            && defendedCard._suitNumber > 1
            && defendingCard._suitNumber > 1
        )
        {
            if (defendingCard._number > defendedCard._number || defendedCard._card.IsDebuffed())
            {
                return true;
            }
            else
            {
                if (ShowErrorResponses)
                {
                    _responseText.AddToResponseText(
                        $"{defendingCard.CompileCardName()} does not have a larger number than {defendedCard.CompileCardName()}"
                    );
                }
                return false;
            }
        }
        if (
            defendedCard._opponentCard
            && GameHandler.Instance.GetGameState()._redCardsSameSuit
            && defendedCard._suitNumber < 2
            && defendingCard._suitNumber < 2
        )
        {
            if (defendingCard._number > defendedCard._number || defendedCard._card.IsDebuffed())
            {
                return true;
            }
            else
            {
                if (ShowErrorResponses)
                {
                    _responseText.AddToResponseText(
                        $"{defendingCard.CompileCardName()} does not have a larger number than {defendedCard.CompileCardName()}"
                    );
                }
                return false;
            }
        }
        if (defendedCard._suit == defendingCard._suit)
        {
            if (defendingCard._number > defendedCard._number || defendedCard._card.IsDebuffed())
            {
                return true;
            }
            else
            {
                if (ShowErrorResponses)
                {
                    _responseText.AddToResponseText(
                        $"{defendingCard.CompileCardName()} does not have a larger number than {defendedCard.CompileCardName()}"
                    );
                }
                return false;
            }
        }
        else if (defendedCard._card.IsDebuffed())
        {
            return true;
        }
        else if (defendingCard._suit == _ruleHandler.GetTrumpSuit())
        {
            return true;
        }
        else if (defendingCard.IsLaika() || defendedCard.IsLaika())
        {
            return true;
        }
        else
        {
            if (ShowErrorResponses)
            {
                _responseText.AddToResponseText(
                    $"{defendingCard.CompileCardName()} cannot defend {defendedCard.CompileCardName()}!"
                );
            }
            return false;
        }
    }

    public bool CanReverseWithCard(CardInfo card, bool ShowErrorResponses = false)
    {
        if (_cardsDefendedWith.Count > 0 || !GameHandler.Instance.GetGameState()._reversePossible)
        {
            if (ShowErrorResponses)
            {
                _responseText.AddToResponseText(
                    $"Cannot reverse when there are already cards defended!"
                );
            }
            return false;
        }
        else if (CanReverseWithAnotherCard())
        {
            foreach (Card cardPlayed in _cardsPlayed)
            {
                if (card._number != cardPlayed.GetCardInfo()._number)
                {
                    if (ShowErrorResponses)
                    {
                        _responseText.AddToResponseText(
                            $"Cannot attack with {card.CompileCardName()}"
                        );
                    }
                    return false;
                }
            }
            return true;
        }
        if (ShowErrorResponses)
        {
            _responseText.AddToResponseText("Cannot reverse with another card!");
        }
        return false;
    }

    public async Task Wipe()
    {
        foreach (Card card in _cardsDefendedWith)
        {
            _discard.AddCard(card);
            card.RemoveCardArrows();
        }
        foreach (Card card in _cardsPlayed)
        {
            _discard.AddCard(card);
            card.RemoveCardArrows();
        }
        _cardsDefendedWith = new List<Card>();
        _cardsPlayed = new List<Card>();
        _cardsInPlay = 0;
        List<Card> cardsToMove = new List<Card>();

        foreach (RectTransform child in this.transform.Find("PlayedCards"))
        {
            cardsToMove.Add(child.gameObject.GetComponent<Card>());
        }
        foreach (RectTransform child in this.transform.Find("DefendedCards"))
        {
            cardsToMove.Add(child.gameObject.GetComponent<Card>());
        }
        var moveTasks = new List<Task>();
        foreach (Card card in cardsToMove)
        {
            moveTasks.Add(card.MoveTowardsDiscard(true)); //this makes on played card discard trigger
        }
        await Task.WhenAll(moveTasks);
    }

    public void RealignDefendingCards()
    {
        foreach (RectTransform cardTransform in this.transform.Find("PlayedCards"))
        {
            Card card = cardTransform.GetComponent<Card>();
            if (card.IsDefended())
            {
                Card Defendor = card.GetCardDefending();
                RectTransform defendorRect = Defendor.gameObject.GetComponent<RectTransform>();
                defendorRect.anchoredPosition = card.GetDefendPosition();
            }
        }
    }

    public void ReverseArrowsOnPlayedCards()
    {
        foreach (Card card in _cardsPlayed)
        {
            if (!card.IsDefended())
            {
                card.UpdateCardArrows();
            }
        }
    }

    public void SetUndefendableCardsLowOpacity(CardInfo card)
    {
        foreach (Card c in _cardsPlayed)
        {
            if (!c.IsDefended())
            {
                c.SetVisualToDefendableForm(card);
            }
        }
    }

    public void ResetCardDefendableVisuals()
    {
        foreach (Card c in _cardsPlayed)
        {
            c.ResetVisualOpacity();
        }
    }
}
