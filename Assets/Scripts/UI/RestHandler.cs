using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestHandler : MonoBehaviour
{
    private LifeTotal _lifeTotal;
    [SerializeField]
    private TextMeshProUGUI _restPointContent;
    [SerializeField]
    private GameObject _restPointPrefab;
    private Deck _deck;
    void Awake()
    { 
        _lifeTotal= GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
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
        _restPointContent.text=$"{StylisticClass.RestPoint}{GameHandler.Instance.GetGameState()._restPoints}";
    }
}
