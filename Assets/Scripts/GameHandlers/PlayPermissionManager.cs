using System;
using System.Collections.Generic;

[Serializable]
public class PlayPermissionManager 
{
    //number-> suit-> 0=player 1=enemy-> boolean representing if card can be played 
    public  Dictionary<int, Dictionary<string, bool[]>> _playPermissionsCard;
    public Dictionary<string, bool[]> _playPermissionsModifier;
    public PlayPermissionManager()
    {
        ResetPermissions();
    }
    public bool  CanPlayCard(CardInfo card, int turnState)
    {
        foreach (CardModifierContainer modifier in card._modifiers)
        {
            if (_playPermissionsModifier.ContainsKey(modifier.ModType))
            {
                if (!_playPermissionsModifier[modifier.ModType][turnState])
                {
                    return false;
                }
            }
        }
        if (_playPermissionsCard[card._number].ContainsKey(card._suit))
        {
            return _playPermissionsCard[card._number][card._suit][turnState];
        }
        return false;
    }
    public void ResetPermissions() 
    {
        _playPermissionsCard = new Dictionary<int, Dictionary<string, bool[]>>();
        for(int i=6; i<15; i++)
        {
            _playPermissionsCard[i] = new Dictionary<string, bool[]>();
            _playPermissionsCard[i]["C"] = new bool[2]{true, true};
            _playPermissionsCard[i]["D"] = new bool[2]{true, true};
            _playPermissionsCard[i]["H"] = new bool[2]{true, true};
            _playPermissionsCard[i]["S"] = new bool[2]{true, true};
        }
        _playPermissionsModifier = new Dictionary<string, bool[]>();
        foreach (string modifier in CardInfo.modifierStringToType.Keys)
        {
            _playPermissionsModifier[modifier] = new bool[2]{true, true};
        }
    }
}