using System.IO;
using UnityEngine;

public class SaveManager
{
    public void Save(GameState gameState) 
    {
        gameState.SaveItems();
        string JSONGameState = JsonUtility.ToJson(gameState,true);
        string path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
        File.WriteAllText(path, JSONGameState);
        Debug.Log("Saving to: " + Path.Combine(Application.persistentDataPath, "SaveGame.json"));
    }
    public GameState Load() 
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "SaveGame.json")))
        {
            string path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
            string JSONloaded=File.ReadAllText(path);
            GameState gameState = JsonUtility.FromJson<GameState>(JSONloaded);
            gameState.LoadItems();
            return gameState;
        }
        else {  return null; }
    }
}
