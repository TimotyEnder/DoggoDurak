using System;
using UnityEngine;

public class RuleHandler : MonoBehaviour
{
    private PlayArea _playArea;
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
    private bool GameStateFinished = false;
    private bool _modEffectsSpawn;

    void Awake()
    {
            _modEffectsSpawn=true;
    }
    void Init()
    {

        _playerHp = GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
        _opponentHp = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
        _playArea= GameObject.Find("PlayArea").GetComponent<PlayArea>();
    }
    public bool isGameStateFinished()
    {
        return GameStateFinished;
    }
    public bool CanEffectsSpawn()
    {
        return _modEffectsSpawn;
    }
    public void SetEffectsSpawn(bool set)
    {
        _modEffectsSpawn=set;
    }
    public void SetTrumpSuit(string suit) 
    {
        _trumpSuit = suit;  
    }
    public string GetTrumpSuit() 
    {
        return _trumpSuit;
    }
    public async void CheckGameState() 
    {
        if(!GameStateFinished)
        {
            if (_playerHp == null) 
            {
                Init();
            }
            if (_playerHp.GetHealth() <= 0 && !GameHandler.Instance.GetGameState()._loseToWin)
            {
                _modEffectsSpawn=false; 
                WipeModEffects();
                _playerHp.reportHealth();
                _endMatchScreen.SetActive(true);
                _endMatchScreen.GetComponent<Animator>().SetTrigger("Extend");
                _defeat.SetActive(true);
            }
            else if (_opponentHp.GetHealth() <= 0 || (GameHandler.Instance.GetGameState()._loseToWin && _playerHp.GetHealth() <= 0))
            {
                _modEffectsSpawn=false;
                WipeModEffects();
                GameObject.Find("Deck").GetComponent<Deck>().LoadDiscard();
                //GameObject.Find("Discard").GetComponent<Discard>().WipeDiscard();  maybe replace by discard cards returning to the deck one by one?
                _playerHp.reportHealth(); //this has to happen before reward because CurrencyCalculators rely on _health being already updated!
                if(_opponentHp.GetHealth()<=0 && GameHandler.Instance.GetGameState()._loseToWin)
                {
                    GameHandler.Instance.GetCurrEncounter().SetRewardMod(0);
                }
                GameHandler.Instance.GenerateReward();
                _endMatchScreen.SetActive(true);
                _playArea.Wipe();
                _endMatchScreen.GetComponent<Animator>().SetTrigger("Extend");
                _victory.SetActive(true);
                _rewardItemGrid.SetRewardGrid();
                GameStateFinished = true;
            }
        }
    }
    private void WipeModEffects()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("ModEffect"))
        {
            Destroy(obj);
        }
    }
}
