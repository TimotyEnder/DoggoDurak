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
        _opponent.initDeck();
        _playerDeck.initDeck();
        _playerHp.SetHealth(40);
        _opponentHp.SetHealth(40);
        Turn();
    }
    void Update()
    {
        
    }
    void Turn() 
    {
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
        _opponent.CheckForPlays();
        //Damage Co-Routine
        StartCoroutine(DamageRoutine());
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
                    _playerHp.Damage(card.GetCard().getNumber());
                }
                else 
                {
                    _opponentHp.Damage(card.GetCard().getNumber());
                }
                    yield return new WaitForSeconds(0.75f);
                card.transform.eulerAngles = Vector3.zero;
           }
        }
        FinishEndTurn();
    }
}
