using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking
    private int _turn=0;
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
    private Animator _turnIndicatorAnim;
    private TextMeshProUGUI _turnIndicatorText;
    private  int OldTurnState=0;
    void Awake()
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
        _turnIndicatorAnim= GameObject.Find("TurnIndicator").GetComponent<Animator>();
        _turnIndicatorText= GameObject.Find("TurnIndicator").GetComponentInChildren<TextMeshProUGUI>();
    }
    private void TurnIndicatorLaunch()
    {
        _turn++;
        _turnIndicatorText.text=$"Turn {_turn}";
        _turnIndicatorAnim.SetTrigger("Cycle");
    }
    void Start()
    {
        //Init Setup
        _ = InitSetup();
    }
    private async Task InitSetup()
    {
        _turnStateToggle.Toggle();
        _toggled = true;
        _ruleHandler.SetTrumpSuit(_trumpIndicator.SelectTrump());
        _trumpIndicator.Appear();
        _opponent.LoadDeck();
        _playerDeck.LoadDeck();
        _playerHp.SetHealth(GameHandler.Instance.GetGameState()._health);
        _opponentHp.SetHealth(GameHandler.Instance.GetCurrEncounter().GetHealth());
        await  Turn();
    }
    void Update()
    {
        
    }
    async Task Turn() 
    {
        TurnIndicatorLaunch();
        await _ruleHandler.CheckGameState();
        GameHandler.Instance.EncounterSetDebuffs();
        _opponent.resetEndTurnFlag();
        await _playerDeck.DrawHand();
        await _opponent.DrawHand();
        if (OldTurnState == 0)
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
        _turnState=OldTurnState;
    }
    public async Task StartEndTurn() 
    {
        Debug.Log("Start End Turn! Checking if turn end conditions are met! Cards in play: "+_playArea.GetCardsInPlay()+" Has more plays?:"+_playerHand.HasMorePlays());
        if ((_playArea.GetCardsInPlay()>0 || !_playerHand.HasMorePlays()) &&!_turnEndStarted) 
        {
            _turnEndStarted=true;
            OldTurnState=_turnState;
            StartCoroutine(_opponent.CheckForPlaysRoutine(true));//this is to prevent a turn end inside a turn end.
            //Damage Co-Routine
            await  DamageRoutine();

        }
    }
    public async Task FinishEndTurn() 
    {
        //Wipe Cards
        _turnEndStarted=false;
        GameHandler.Instance.ResetDebuffs();
        GameHandler.Instance.ResetPersistentItems();
        await _playArea.Wipe();
        if(!_ruleHandler.isGameStateFinished())
        {
            //Change Turn State
            if (OldTurnState == 0)
            {
                OldTurnState = 1;
            }
            else
            {
                OldTurnState = 0;
            }
            await  Turn();
        }
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
    private async Task DamageRoutine() 
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
                await UniTask.Delay(800);
                card.SetAnimatable(false);
                card.GetComponent<RectTransform>().eulerAngles = Vector3.zero;
           }
        }
        await _ruleHandler.CheckGameState();
        if(!_ruleHandler.isGameStateFinished()){
            await UniTask.Delay(200);
            GameHandler.Instance.GetCurrEncounter().OnTurnEnd(_turnState);
            GameHandler.Instance.GetGameState().OnTurnEnd(_turnState);
            await UniTask.Delay(200);
            await FinishEndTurn();
        }
    }
    public bool IsTurnEnding() 
    {
        return _turnEndStarted;
    }   
}
