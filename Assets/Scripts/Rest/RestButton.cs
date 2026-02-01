using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestButton : MonoBehaviour
{
    public Button _restButton;
    void Start()
    {
        _restButton = this.gameObject.GetComponent<Button>();
        _restButton.onClick.AddListener(RestButtonOnClick);
    }
    void RestButtonOnClick()
    {
        if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._restRpointCost)
        {
            GameHandler.Instance.GetGameState()._restPoints -= GameHandler.Instance.GetGameState()._restRpointCost;
            GameHandler.Instance.HealPlayer(Mathf.RoundToInt(GameHandler.Instance.GetGameState()._maxhealth * 0.5f),true);
            GameObject.Find("RestHandler").GetComponent<RestHandler>().UpdateRestUI();
        }
        else 
        {
            //add red color blink to indicate operation impossible
        }
    }
}
