using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking

    private Deck _deck;
    private TurnStateToggle _turnStateToggle;
    private TrumpCardIndicator _trumpIndicator;
    private RuleHandler _ruleHandler;
    void Start()
    {
        //initialising
        _deck = GameObject.Find("Deck").GetComponent<Deck>();
        _turnStateToggle= GameObject.Find("TurnStateToggle").GetComponent<TurnStateToggle>();   
        _trumpIndicator= GameObject.Find("TrumpCardIndicator").GetComponent<TrumpCardIndicator>(); 
        _ruleHandler = GameObject.Find("RuleHandler").GetComponent<RuleHandler>(); 
        //Init Setup
        InitSetup();
    }
    private void InitSetup()
    {
        _turnStateToggle.Toggle();
        _ruleHandler.SetTrumpSuit(_trumpIndicator.SelectTrump());
        _trumpIndicator.Appear();
        _deck.initDeck();
        _deck.DrawHand();
    }
    void Update()
    {
        
    }
    public int GetTurnState() 
    {
        return _turnState;
    }
    public void EndTurn()
    {
        if (_turnState == 0) 
        {
            _turnState = 1;
        }
        else 
        {
            _turnState = 0;
        }
        _turnStateToggle.Toggle();
    }
}
