using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;
    private GameState _state;
    private Lazy<SaveManager> _saveManager = new Lazy<SaveManager>(); //elegant fix to start init issue
    private Lazy<RewardManager> _rewardManager = new Lazy<RewardManager>();
    private EncounterManager _encounterManager;
    private Encounter _currentEncounter;
    [SerializeField]
    private Reward _currentReward;

    public static GameHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameHandler>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameHandler).Name);
                    _instance = singleton.AddComponent<GameHandler>();
                    DontDestroyOnLoad(singleton);
                }

            }
            return _instance;
        }
    }
    void Start()
    {
        _instance = this;
        DontDestroyOnLoad(this);
        _encounterManager = new EncounterManager();
    }
    public bool HasSave()
    {
        return _saveManager.Value.Load() != null;
    }
    public void NewGame()
    {
        _state = new GameState();
        _saveManager.Value.Save(_state);
        //debug
        foreach (CardInfo c in _state._deck)
        {
            //c.AddModifier("Burn");
        }
        //debug

        /*Item debugItem = ScriptableObject.CreateInstance<RedStar>();
        debugItem.InitItem();
        _state.AddItem(debugItem);
        Item debugItem2 = ScriptableObject.CreateInstance<BlackStar>();
        debugItem2.InitItem();
        _state.AddItem(debugItem2);*/
        Next();
    }
    public void Continue() //enters only if hasSave returns true but if somehow trying to acess without pressing the button
    {
        if (HasSave())
        {
            _state = _saveManager.Value.Load();
            Next();
        }
    }
    public void Next() // will be called after an encounter or rest is finished and will handle what should happen next
    {
        //_state._encounter = 2; //debug
        _saveManager.Value.Save(_state);
        _state._encounter++;
        if ((_state._encounter) % 4 == 0 && _state._encounter > 0) //every three encounters you have a rest
        {
            SceneManager.LoadScene(2);
        }
        else if (_state._encounter < 11)
        {
            _currentEncounter = _encounterManager.RandomEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        else
        {
            _state._day++;
            _state._encounter = 0;
            SceneManager.LoadScene(1);
        }
    }
    public GameState GetGameState()
    {
        return _state;
    }
    public Encounter GetCurrEncounter()
    {
        return _currentEncounter;
    }
    public Reward GetCurrReward()
    {
        return _currentReward;
    }
    public void GenerateReward()
    {
        _currentReward = _rewardManager.Value.GenerateReward();
    }
    public List<Item> GetShopItems() 
    {
        List<Item> itemsToReturn = new List<Item>();
        int legendaryItemsInShop = 0;
        for (int i = 0; i < GameHandler.Instance.GetGameState()._itemsShownInShop; i++)
        {
            int random = UnityEngine.Random.Range(1, 100);
            if (random <= GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate)
            {
                legendaryItemsInShop++;
            }
        }
        itemsToReturn.AddRange(_rewardManager.Value.ShopReward(2, legendaryItemsInShop));
        itemsToReturn.AddRange(_rewardManager.Value.ShopReward(1,_state._itemsShownInShop - legendaryItemsInShop));
        return itemsToReturn;   
    }
    public void SetHealth(int health)
    {
        _state._lastHealth = _state._health;
        _state._health = health;
        if (_state._health > _state._maxhealth)
        {
            _state._health = _state._maxhealth;
        }
    }
    public void GameStateHeal(int amount) //heal directly to savefile, used when resting
    {
        SetHealth(_state._health + amount);
    }
    //Heal From effect should be true for heals comes from item/card effects to not create an infinite chain of healing!
    public void HealPlayer(int amount, bool fromEffect = false) //any healing effects should be handled by this
    {
        if (GameObject.Find("PlayerLifeTotal") != null && GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Heal(amount);
        }
        if (!fromEffect)
        {
            _state.OnHeal(amount);
        }
    }
    public void HealOpponent(int amount) //any healing effects should be handled by this
    {
        if (GameObject.Find("OpponentsLifeTotal") != null && GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().Heal(amount);
        }
    }
    public void DamageOpponent(int amount, bool fromEffect = false) //any effects damaging the enemy should go through this
    {
        if (GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().Damage(amount);
            GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState();//opponent might be dead mid-turn
        }
        if (!fromEffect)
        {
            _state.OnDamageOpponent(amount);
        }
    }
    public void DamagePlayer(int amount) //any effects damaging the player should go through this
    {
        if (GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Damage(amount);
            GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState(); //player might be dead mid-turn
        }
    }
    public void Draw(int amount)
    {
        if (GameObject.Find("Deck").GetComponent<Deck>() != null)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject.Find("Deck").GetComponent<Deck>().Draw();
            }
        }
    }
    public void OpponentDiscard(int amount)
    {
        if (GameObject.Find("Opponent").GetComponent<OpponentLogic>() != null)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject.Find("Opponent").GetComponent<OpponentLogic>().Discard();
            }
        }
    }
    public void ReAddItems(List<Item> items)
    {
        _rewardManager.Value.ReAddItems(items);
    }
    public void SortDeck()
    {
        _state._deck.Sort((a, b) => a._suitNumber == b._suitNumber?a._number.CompareTo(b._number):a._suitNumber.CompareTo(b._suitNumber));
    }

}
