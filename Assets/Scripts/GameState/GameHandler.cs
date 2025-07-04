using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;
    private GameState _state;
    private Lazy<SaveManager> _saveManager= new Lazy<SaveManager>(); //elegant fix to start init issue
    private EncounterManager _encounterManager;
    private Encounter _currentEncounter;
    public static GameHandler Instance 
    {
        get
        {
            if (_instance == null) 
            {
                _instance = FindFirstObjectByType<GameHandler>();
                if( _instance == null ) 
                {
                    GameObject singleton= new GameObject(typeof(GameHandler).Name);
                    _instance= singleton.AddComponent<GameHandler>(); 
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
        /*foreach (CardInfo c in _state._deck)
        {
            c.addModifier("Restoring");
        }*/
        /*
        Item debugItem = ScriptableObject.CreateInstance<DachaDoorstep>();
        debugItem.InitItem();
        _state.AddItem(debugItem);
        */
        Next();
    }
    public void Continue() //enters only if hasSave returns true but if somehow trying to acess without pressing the button
    {
        if (HasSave()) 
        {
            _state=_saveManager.Value.Load();
            Next();
        }
    }
    public void Next() // will be called after an encounter or rest is finished and will handle what should happen next
    {
        //_state._encounter = 2; //debug
        _saveManager.Value.Save(_state);
        if ((_state._encounter+1)%3==0) //every three encounters you have a rest
        {
            SceneManager.LoadScene(2);
        }
        else if (_state._encounter < 6)
        {
            _state._encounter++;
            _currentEncounter = _encounterManager.RandomEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        else
        {
            _state._day++;
            _state._encounter = 0;
            //load resting area
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
    public void SetHealth(int health) 
    {
        _state._health = health;
        if (_state._health > _state._maxhealth) 
        {
            _state._health= _state._maxhealth;
        }
    }
    //Heal From effect should be true for heals comes from item/card effects to not create an infinite chain of healing!
    public void HealPlayer(int amount, bool healFromEffect=false) //any healing effects should be handled by this
    {
        if(GameObject.Find("PlayerLifeTotal") != null && GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>()!=null) 
        {
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Heal(amount);
        }
        if (!healFromEffect) 
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
    public void DamageOpponent(int amount) //any effects damaging the enemy should go through this
    {
        if (GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().Damage(amount);
            GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState();//opponent might be dead mid-turn
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
}
