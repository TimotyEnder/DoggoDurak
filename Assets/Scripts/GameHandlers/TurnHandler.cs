using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking

    private Deck _deck;
    private TurnStateToggle _turnStateToggle;
    void Start()
    {
        //initialising
        _deck = GameObject.Find("Deck").GetComponent<Deck>();
        _turnStateToggle= GameObject.Find("TurnStateToggle").GetComponent<TurnStateToggle>();   

        //Init Setup
        InitSetup();
    }
    private void InitSetup()
    {
        _turnStateToggle.Toggle();
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
}
