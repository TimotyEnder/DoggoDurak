using UnityEngine;

public class RuleHandler : MonoBehaviour
{
    [SerializeField]
    private string _trumpSuit;
    [SerializeField]
    private GameObject _endMatchScreen;
    [SerializeField]
    private GameObject _victory;
    [SerializeField]
    private GameObject _defeat;
    private LifeTotal _playerHp;
    private LifeTotal _opponentHp;
    [SerializeField]
    private RewardItemGrid _rewardItemGrid;
    void Init()
    {

        _playerHp = GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
        _opponentHp = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
    }
    public void SetTrumpSuit(string suit) 
    {
        _trumpSuit = suit;  
    }
    public string GetTrumpSuit() 
    {
        return _trumpSuit;
    }
    public void CheckGameState() 
    {
        if (_playerHp == null) 
        {
            Init();
        }
        if (_playerHp.GetHealth() <= 0)
        {
            _playerHp.reportHealth();
            _endMatchScreen.SetActive(true);
            _defeat.SetActive(true);
        }
        else if (_opponentHp.GetHealth() <= 0) 
        {
            GameObject.Find("Deck").GetComponent<Deck>().LoadDiscard();
            GameHandler.Instance.GenerateReward();
            _playerHp.reportHealth();
            _endMatchScreen.SetActive(true);
            _victory.SetActive(true);
            _rewardItemGrid.SetRewardGrid();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
