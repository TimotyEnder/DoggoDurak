using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class EndTurnButton : MonoBehaviour
{
    public Button _endTurnButton;
    public TurnHandler _turnHandler;
    void Start()
    {
        _endTurnButton = this.GetComponent<Button>();
        _turnHandler = GameObject.Find("TurnHandler").GetComponent<TurnHandler>();
        _endTurnButton.onClick.AddListener(OnEndTurnClick);
    }
    void OnEndTurnClick() 
    {
        _turnHandler.StartEndTurn();
    }
}
