using System;
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
    private bool GameStateFinished = false;
    private bool _modEffectsSpawn=true;
    void Init()
    {

        _playerHp = GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>();
        _opponentHp = GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>();
    }
    public bool CanEffectsSpawn()
    {
        return _modEffectsSpawn;
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
        if(!GameStateFinished)
        {
            if (_playerHp == null) 
            {
                Init();
            }
            if (_playerHp.GetHealth() <= 0)
            {
                _modEffectsSpawn=false; 
                WipeModEffects();
                _playerHp.reportHealth();
                _endMatchScreen.SetActive(true);
                _defeat.SetActive(true);
            }
            else if (_opponentHp.GetHealth() <= 0)
            {
                _modEffectsSpawn=false;
                WipeModEffects();
                GameObject.Find("Deck").GetComponent<Deck>().LoadDiscard();
                _playerHp.reportHealth(); //this has to happen before reward because CurrencyCalculators rely on _health being already updated!
                GameHandler.Instance.GenerateReward();
                _endMatchScreen.SetActive(true);
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
