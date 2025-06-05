using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;
    private GameState _state;
    private Lazy<SaveManager> _saveManager= new Lazy<SaveManager>(); //elegant fix to start init issue
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
    }
    public bool HasSave() 
    {
        return _saveManager.Value.Load() != null;
    }
    public void NewGame() 
    {
        _state = new GameState();
        _saveManager.Value.Save(_state);
    }
    public void Continue() //enters only if hasSave returns true but if somehow trying to acess without pressing the button
    {
        if (HasSave()) 
        {
            _state=_saveManager.Value.Load();
        }
    }
    public GameState GetGameState() 
    {
        return _state;
    }
    void Update()
    {
        
    }
}
