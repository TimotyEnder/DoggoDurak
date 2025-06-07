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
        Next();
    }
    public void Continue() //enters only if hasSave returns true but if somehow trying to acess without pressing the button
    {
        if (HasSave()) 
        {
            _state=_saveManager.Value.Load();
        }
    }
    public void Next() // will be called after an encounter or rest is finished and will handle what should happen next
    {
        _saveManager.Value.Save(_state);
        if (_state._encounter == -1) 
        {
            //resting area load also
        }
        else if (_state._encounter < 3)
        {
            _state._encounter++;
            _currentEncounter = _encounterManager.RandomEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        else
        {
            _state._day++;
            _state._encounter = -1;
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
    }
}
