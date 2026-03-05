using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking

    private Deck _playerDeck;
    private TurnStateToggle _turnStateToggle;
    private bool _toggled;//player Attacking
    private TrumpCardIndicator _trumpIndicator;
    private RuleHandler _ruleHandler;
    private PlayArea _playArea;
    private OpponentLogic _opponent;
    private LifeTotal _playerHp;
    private LifeTotal _opponentHp;
    private CardHandArea _playerHand;
    private bool _turnEndStarted=false;
    void Start()
    {
        //initialising
        _playerDeck = GameObject.Find("Deck").GetComponent<Deck>();
        _turnStateToggle= GameObject.Find("TurnStateToggle").GetComponent<TurnStateToggle>();   
        _trumpIndicator= GameObject.Find("TrumpCardIndicator").GetComponent<TrumpCardIndicator>(); 
        _ruleHandler = GameObject.Find("RuleHandler").GetComponent<RuleHandler>();
        _playArea = GameObject.Find("PlayArea").GetComponent<PlayArea>();
        _opponent = GameObject.Find("Opponent").GetComponent<OpponentLogic>();
        _playerHp= GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>(); 
        _opponentHp = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
        _playerHand = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        //Init Setup
        InitSetup();
    }
    private void InitSetup()
    {
        _turnStateToggle.Toggle();
        _toggled = true;
        _ruleHandler.SetTrumpSuit(_trumpIndicator.SelectTrump());
        _trumpIndicator.Appear();
        _opponent.LoadDeck();
        _playerDeck.LoadDeck();
        _playerHp.SetHealth(GameHandler.Instance.GetGameState()._health);
        _opponentHp.SetHealth(GameHandler.Instance.GetCurrEncounter().GetHealth());
        Turn();
    }
    void Update()
    {
        
    }
    void Turn() 
    {
        _ruleHandler.CheckGameState();
        GameHandler.Instance.EncounterSetDebuffs();
        _opponent.resetEndTurnFlag();
        StartCoroutine(_playerDeck.DrawHandRoutine());
        StartCoroutine(_opponent.DrawHandRoutine());
        if (_turnState == 0)
        {
            if (!_toggled)
            {
                _turnStateToggle.Toggle();
                _toggled = true;
            }
        }
        else 
        {
            if (_toggled)
            {
                _turnStateToggle.Toggle();
                _toggled = false;
            }
            _opponent.Attack();
        }

    }
    public void StartEndTurn() 
    {
        Debug.Log("Start End Turn! Checking if turn end conditions are met! Cards in play: "+_playArea.GetCardsInPlay()+" Has more plays?:"+_playerHand.HasMorePlays());
        if ((_playArea.GetCardsInPlay()>0 || !_playerHand.HasMorePlays()) &&!_turnEndStarted) 
        {
            _turnEndStarted=true;
            StartCoroutine(_opponent.CheckForPlaysRoutine(true));//this is to prevent a turn end inside a turn end.
            //Damage Co-Routine
            StartCoroutine(DamageRoutine());

        }
    }
    public void FinishEndTurn() 
    {
        //Wipe Cards
        _turnEndStarted=false;
        _playArea.Wipe();
        GameHandler.Instance.ResetDebuffs();

        GameHandler.Instance.ResetPersistentItems();
        //Change Turn State
        if (_turnState == 0)
        {
            _turnState = 1;
        }
        else
        {
            _turnState = 0;
        }
        Turn();
    }
    public int GetTurnState() 
    {
        return _turnState;
    }
    public void Reverse() 
    {
        if (_turnState == 0)
        {
            _turnState = 1;
        }
        else
        {
            _turnState = 0;
        }
        if (_turnState == 0)
        {
            if (!_toggled)
            {
                _turnStateToggle.Toggle();
                _toggled = true;
            }
        }
        else
        {
            if (_toggled)
            {
                _turnStateToggle.Toggle();
                _toggled = false;
            }
        }
    }
    private IEnumerator DamageRoutine() 
    {
        foreach (Card card in _playArea.GetCardsPlayed()) 
        {
           if(!card.IsDefended()){ 
                card.SetAnimatable(true);
                card.Hit();
                int damage=0;
                if(GameHandler.Instance.IsCardnotDebuffed(card.GetCardInfo(), card.GetCardInfo()._opponentCard ? 1 : 0))
                {
                    damage = card.GetCardInfo()._number;
                }
                if (_turnState > 0)
                {
                    GameHandler.Instance.DamagePlayer(damage,checkMatchEnd:false);
                }
                else
                {
                    GameHandler.Instance.DamageOpponent(damage, checkMatchEnd:false);
                }
                yield return new WaitForSeconds(0.8f);
                card.SetAnimatable(false);
                card.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
           }
        }
        _ruleHandler.CheckGameState();
        if(!_ruleHandler.isGameStateFinished()){
            yield return new WaitForSeconds(0.2f);
            GameHandler.Instance.GetCurrEncounter().OnTurnEnd(_turnState);
            yield return new WaitForSeconds(0.2f);
            FinishEndTurn();
        }
    }
    public bool IsTurnEnding() 
    {
        return _turnEndStarted;
    }   
}
