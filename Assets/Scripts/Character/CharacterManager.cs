using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CharacterManager
{
    private Dictionary<string,Character> _chars;
    public CharacterManager()
    {
        _chars = new Dictionary<string, Character>();
        var loadedCharacters = Resources.LoadAll<Character>("Characters");
        foreach (var i in loadedCharacters)
        {
            Character runtimeCharacter = Object.Instantiate(i); // Create a safe copy
            runtimeCharacter.InitCharacter();
            _chars.Add(runtimeCharacter.GetID(),runtimeCharacter);
        }
    }
    public Character SelectChar(string charId)
    {
        return _chars[charId];
    }
    public LoopList<Character> GetCharacterInfo()
    {
        return new LoopList<Character>(_chars.Values.ToList());
    }
}