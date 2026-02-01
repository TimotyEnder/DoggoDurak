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
        _restPointsText= GameObject.Find("RestPointsText").GetComponent<TextMeshProUGUI>();
        _lifeTotal.SetHealth(GameHandler.Instance.GetGameState()._health);
        UpdateRestUI();
    }
    public void UpdateRestUI()
    {
        _restPointsText.text = "R:" + GameHandler.Instance.GetGameState()._restPoints.ToString();
    }
}
