using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestHandler : MonoBehaviour
{
    private Button _restButton;
    private LifeTotal _lifeTotal;
    private TextMeshProUGUI _restPointsText;
    private Deck _deck;
    void Awake()
    { 
        _lifeTotal= GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
        _restPointsText= GameObject.Find("RestPointsText").GetComponent<TextMeshProUGUI>();
        _deck=GameObject.Find("Deck").GetComponent<Deck>();
        
    }
    void Start()
    {
        UpdateRestUI();
        _deck.LoadDeck();
        _lifeTotal.SetHealth(GameHandler.Instance.GetGameState()._health);
    }
    public void UpdateRestUI()
    {
        _restPointsText.text = "R:" + GameHandler.Instance.GetGameState()._restPoints.ToString();
    }
}
