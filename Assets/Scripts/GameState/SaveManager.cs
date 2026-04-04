using System.IO;
using UnityEngine;

public class SaveManager
{
    public void Save(GameState gameState) 
    {
        gameState._serializableItems=gameState.SaveItems(gameState._items);
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
            gameState._items=gameState.LoadItems(gameState._serializableItems);
            return gameState;
        }
        else {  return null; }
    }
    public void DeleteSaveFileOnCompletion()
    {
        string path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
        File.Delete(path);
    }
}
