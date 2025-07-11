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
        if (_playArea.GetCardsInPlay()>0) 
        {
            StartCoroutine(_opponent.CheckForPlaysRoutine());
            //Damage Co-Routine
            StartCoroutine(DamageRoutine());
        }
    }
    public void FinishEndTurn() 
    {
        //Wipe Cards
        _playArea.Wipe();
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
                card.transform.eulerAngles = new Vector3(0, 0, 10f);
                if (_turnState>0)
                {
                    _playerHp.Damage(card.GetCard()._number);
                }
                else 
                {
                    _opponentHp.Damage(card.GetCard()._number);
                    
                }
                    yield return new WaitForSeconds(0.75f);
                if (_turnState == 0) 
                {
                    GameHandler.Instance.GetGameState().OnDamageOpponent(card.GetCard()._number);
                }
                card.transform.eulerAngles = Vector3.zero;
           }
        }
        FinishEndTurn();
    }
}
