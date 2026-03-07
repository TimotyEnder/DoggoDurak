using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestHandler : MonoBehaviour
{
    private LifeTotal _lifeTotal;
    [SerializeField]
    private RectTransform _restPointContent;
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
        foreach(RectTransform g in _restPointContent.transform)
        {
            Destroy(g.gameObject);
        }
        for(int i=0; i<GameHandler.Instance.GetGameState()._restPoints;i++)
        {
            GameObject restPoint= Instantiate(_restPointPrefab,_restPointContent);
        }
    }
}
