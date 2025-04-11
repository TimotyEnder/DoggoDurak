using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField]
    private int _turnState = 0; //0 your turn to attack, _turnState>0 enemy (_turnState) is attacking
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public int GetTurnState() 
    {
        return _turnState;
    }
}
