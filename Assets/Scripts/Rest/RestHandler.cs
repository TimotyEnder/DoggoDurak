using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestHandler : MonoBehaviour
{
    private Button _restButton;
    private LifeTotal _lifeTotal;
    private TextMeshProUGUI _restPointsText;
    void Start()
    { 
        _lifeTotal= GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
        _lifeTotal.SetHealth(GameHandler.Instance.GetGameState()._health);
        _restPointsText= GameObject.Find("RestPointsText").GetComponent<TextMeshProUGUI>(); 
        _restPointsText.text= "R:"+GameHandler.Instance.GetGameState()._restPoints.ToString();
    }
}
