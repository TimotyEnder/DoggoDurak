using System.IO;
using UnityEngine;

public class SvaeManager : MonoBehaviour
{
    public void Save(GameState gameState) 
    {
        string JSONGameState = JsonUtility.ToJson(gameState,true);
        string path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
        File.WriteAllText(path, JSONGameState);
    }
    public GameState Load() 
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "SaveGame.json")))
        {
            string path = Path.Combine(Application.persistentDataPath, "SaveGame.json");
            string JSONloaded=File.ReadAllText(path);
            GameState gameState = JsonUtility.FromJson<GameState>(JSONloaded);
            return gameState;
        }
        else {  return null; }
    }
}
