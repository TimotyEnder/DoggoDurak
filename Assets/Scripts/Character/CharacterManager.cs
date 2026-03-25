using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CharacterManager
{
    private LoopList<Character>_chars;
    public CharacterManager()
    {
        _chars = new LoopList<Character>();
        var loadedCharacters = Resources.LoadAll<Character>("Characters");
        foreach (var i in loadedCharacters)
        {
            Character runtimeCharacter = Object.Instantiate(i); // Create a safe copy
            runtimeCharacter.InitCharacter();
            _chars.Add(runtimeCharacter);
        }
    }
    public Character SelectChar(string charId)
    {
        foreach(Character c in _chars)
        {
            if(c.GetID()==charId)
            {
                return c;
            }
        }
        return null;
    }
    public LoopList<Character> GetCharacterInfo()
    {
        return _chars;
    }
}