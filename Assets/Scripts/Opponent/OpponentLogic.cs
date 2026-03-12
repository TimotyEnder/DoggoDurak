using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
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

    private LifeTotal _lifeTotalUI;
    private OpponentHand _handUI;
    private TurnHandler _turnHandler;
    private PlayArea _playArea;
    private RuleHandler _ruleHandler;

    private bool endTurnCaused = false;//flag to stop end turn infinite loop 
    private bool _enemyPlaying = false;
    private CardHandArea _cardHandArea;
    private bool[] _doublePass={false,false}; //if you pass once the enemy gets to put more cards down and then if you press pass again you will not defend.
    private Discard _discard;
    [SerializeField]
    private TextMeshProUGUI _responseText;
    private bool _noResponse=true; //if the enemy has no response to the players attack, this is set to true and the response text is set to "No Response" at the end of the player's turn. This is reset at the start of the enemy's turn.
    private bool  _noResponseWritten=false;

    private bool _justReverse=false; //flag to check if the enemy just reversed, so it lets you defend even tho you have not defended yet.
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
    public void AddToDeck(CardInfo card)
    {
        _deck.Add(card);
    }
    public async Task LoadDiscard()
    {
        _deck = new List<CardInfo>();
        foreach(Card c in await _discard.GetOpponentDiscard())
        {
            _deck.Add(c.GetCardInfo());
        }
    }
     private void AttackWithCard(CardInfo cardInHand)
    {
        _hand.Remove(cardInHand);
        _handUI.RemoveCard();
        GameObject CardToAttack = Instantiate(cardMaker);
        CardToAttack.GetComponent<Card>().MakeCard(cardInHand);
        CardToAttack.GetComponent<Card>().PlayCard();
        AddToResponseText(GameHandler.Instance.GetCurrEncounter().GetEncounterName() + " attacks with: "+cardInHand.CompileCardName()+cardInHand.CompileCondencedModifiers());
        _noResponse=false;
    }
    private void ReverseWithCard(CardInfo cardInHand)
    {
        _hand.Remove(cardInHand);
        _handUI.RemoveCard();
        GameObject CardToReverse = Instantiate(cardMaker);
        CardToReverse.GetComponent<Card>().MakeCard(cardInHand);
        CardToReverse.GetComponent<Card>().PlayCard();
        CardToReverse.GetComponent<Card>().GetCardInfo().OnReverse(CardToReverse.GetComponent<Card>());
        GameHandler.Instance.GetGameState().OnReverse(CardToReverse.GetComponent<Card>());
        _justReverse=true;
        _turnHandler.Reverse();
        AddToResponseText(GameHandler.Instance.GetCurrEncounter().GetEncounterName() + " reverses with: "+cardInHand.CompileCardName()+cardInHand.CompileCondencedModifiers());
        _noResponse=false;
    }
    private void DefendWithCard(Card defended, CardInfo chosenToDefend)
    {
        
        _hand.Remove(chosenToDefend);
        _handUI.RemoveCard();
        GameObject CardToDefend = Instantiate(cardMaker);
        CardToDefend.GetComponent<Card>().MakeCard(chosenToDefend);
        CardToDefend.GetComponent<Card>().DefendCard(defended);
        AddToResponseText(GameHandler.Instance.GetCurrEncounter().GetEncounterName() + " defends: "+ defended.GetCardInfo().CompileCardName() +defended.GetCardInfo().CompileCardName()+ " with: "+chosenToDefend.CompileCardName()+chosenToDefend.CompileCondencedModifiers());
        _noResponse=false;
    }
    private CardInfo ChooseBestAtkCard(List<CardInfo> opt)
    {
        opt.Sort((a, b) => a._number.CompareTo(b._number));
        CardInfo choice=opt[0];
        foreach (CardInfo c in opt)
        {
            if(c._modifierStacks.ContainsKey("Spiky")||c._modifierStacks.ContainsKey("Burn")||(choice._suit==_ruleHandler.GetTrumpSuit() && c._suit!=_ruleHandler.GetTrumpSuit()))
            {
                return c;
            }
        }
        return choice;
    }
    private CardInfo ChooseBestDefCard(List<CardInfo> opt)
    {
        opt.Sort((a, b) => a._number.CompareTo(b._number));
        CardInfo choice=opt[0];
        foreach (CardInfo c in opt)
        {
            if(c._modifierStacks.ContainsKey("Restoring")||c._modifierStacks.ContainsKey("Bounce")||(choice._suit==_ruleHandler.GetTrumpSuit() && c._suit!=_ruleHandler.GetTrumpSuit()))
            {
                return c;
            }
        }
        return choice;
    }
    private CardInfo ChooseBestRevCard(List<CardInfo> opt)
    {
        opt.Sort((a, b) => a._number.CompareTo(b._number));
        CardInfo choice=opt[0];
        foreach (CardInfo c in opt)
        {
            if(c._modifierStacks.ContainsKey("Parry")||(choice._suit==_ruleHandler.GetTrumpSuit() && c._suit!=_ruleHandler.GetTrumpSuit()))
            {
                return c;
            }
        }
        return choice;
    }
    //check once for available plays
    bool CheckPlay() 
    {
        //if Enemy attacking check for available attacks
        if (_turnHandler.GetTurnState() > 0)
        {
            List<CardInfo> atkOpt=new List<CardInfo>();
            foreach (CardInfo cardInHand in _hand)
            {
                if (_playArea.CanAttackWithCard(cardInHand))
                {
                    atkOpt.Add(cardInHand);
                }
            }
            if(atkOpt.Count>0)
            {
                AttackWithCard(ChooseBestAtkCard(atkOpt));
                return true;
            }
            return false;
        }
        else
        {
            foreach (Card card in _playArea.GetCardsPlayed())
            {
                if (!card.IsDefended())
                {
                    List<CardInfo> defOpt=new List<CardInfo>();
                    List<CardInfo> revOpt= new List<CardInfo>();
                    foreach (CardInfo cardInHand in _hand)
                    {   
                        Debug.Log("Can play card to defend? "+GameHandler.Instance.IsCardnotDebuffed(cardInHand,1) + " Can card defend? "+ _playArea.CardCanDefendCard(cardInHand, card.GetCardInfo()));
                        //reverse if possible
                        if (_playArea.CanReverseWithCard(cardInHand))
                        {
                            revOpt.Add(cardInHand);
                        }
                        //Defending if cannot reverse
                        else if (_playArea.CardCanDefendCard(cardInHand, card.GetCardInfo()) && GameHandler.Instance.IsCardnotDebuffed(cardInHand,1))
                        {
                            defOpt.Add(cardInHand);
                        }
                    }
                    if(revOpt.Count>0)
                    {
                        ReverseWithCard(ChooseBestRevCard(revOpt));
                        return true;
                    }
                    else if(defOpt.Count>0)
                    {
                        DefendWithCard(card,ChooseBestDefCard(defOpt));
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
        WipeResponseText();
        CardInfo lowerCard = _hand[0];
        foreach(CardInfo card in _hand) 
        {
            if (lowerCard._suit == _ruleHandler.GetTrumpSuit() && card._suit != _ruleHandler.GetTrumpSuit() || !GameHandler.Instance.IsCardnotDebuffed(lowerCard,1) && GameHandler.Instance.IsCardnotDebuffed(card,1))
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
        AddToResponseText(GameHandler.Instance.GetCurrEncounter().GetEncounterName() + " attacks with: "+lowerCard.CompileCardName()+lowerCard.CompileCondencedModifiers());
    }
    public  async void DrawHand()
    {
        Debug.Log("Drawing handsize: "+GameHandler.Instance.GetGameState()._enemyHandSize);
        int toDraw = GameHandler.Instance.GetGameState()._enemyHandSize - _hand.Count;
        for (int i = 0; i < toDraw; i++)
        {
            if (_deck.Count > 0)
            {
                if(Draw())
                {
                   _handUI.AddCard();
                }
            }
            else 
            {
                await LoadDiscard();
                if(Draw())
                {
                   _handUI.AddCard();
                }
            }
            await UniTask.Delay(100);
        }
    }
    bool Draw()
    {
        //CardInfo handling
        int cardDrawIndex = Random.Range(0, _deck.Count);
        if(_deck.Count>0)
        {
            CardInfo cardtoDraw = _deck[cardDrawIndex];
            _deck.Remove(cardtoDraw);
            _hand.Add(cardtoDraw);
            GameHandler.Instance.GetCurrEncounter().OnCardDrawn(cardtoDraw);
            return true;
        }
        return false;
    }
    public void Discard() 
    {
        if (_hand.Count>0) 
        {
            int RandomIndex = Random.Range(0, _hand.Count);
            _discard.AddCard(_cardHandArea.GetCards()[RandomIndex]); //add to discard pile if a card is discarded
            GameHandler.Instance.GetCurrEncounter().OnHandCardDiscarded(_hand[RandomIndex]);
            _hand.RemoveAt(RandomIndex);
            _handUI.RemoveCard();
        }
    }
    public void DiscardAt(int index) 
    {
        if (_hand.Count>0 && index < _hand.Count) 
        {
            _discard.AddCard(_cardHandArea.GetCards()[index]); //add to discard pile if a card is discarded
            _hand.RemoveAt(index);
            _handUI.RemoveCard();
        }
    }
    public async Task EnemyPlay() 
    {
        _enemyPlaying = true;
        _cardHandArea.GreyInAllCards();
        WipeResponseText();
        await UniTask.NextFrame();
        await CheckForPlaysRoutine();
    }
    
    public async Task CheckForPlaysRoutine( bool fromTurnEnd=false)
    { 
        await UniTask.Delay(500);
        while (CheckPlay()) 
        {
            await UniTask.Delay(500);
        }
        if(_noResponse && !_noResponseWritten)
        {
            AddToResponseText(GameHandler.Instance.GetCurrEncounter().GetEncounterName() + " has no response!");
            _noResponseWritten = true;
        }
        CardHandArea cha = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        Debug.Log("Enemy Turn Routine! Has more plays?:"+cha.HasMorePlays() +" Double Pass?:"+_doublePass[_turnHandler.GetTurnState()]);

        if (!endTurnCaused && cha != null && (!cha.HasMorePlays() || _doublePass[_turnHandler.GetTurnState()] || (_turnHandler.GetTurnState()==1 && _playArea.UnblockedCardsAmount()==_playArea.GetCardsInPlay() && !_justReverse)) && !fromTurnEnd) 
        {
            endTurnCaused = true;
            _=_turnHandler.StartEndTurn();
        }
        else
        {
            _doublePass[_turnHandler.GetTurnState()]=true;
        }
        _justReverse=false;
        _enemyPlaying = false;
        _noResponse=true;  
        _cardHandArea.GreyOutAllCards();
    }
    public void resetDoublePass()
    {
        _doublePass=new bool[]{false,false};
    }
    public void resetEndTurnFlag() 
    {
        endTurnCaused = false;
    }
    private void WipeResponseText() 
    {
        _responseText.text = "";
        _noResponseWritten=false; 
    } 
    private void AddToResponseText(string textToAdd) 
    {
        _responseText.text += "<wave  a=0.1>" + textToAdd + "</wave>\n";
    }  
}
