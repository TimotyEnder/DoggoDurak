using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.InputSystem.Controls;

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
    //how to use:
    // [One Character For Suit]{Number} = disables cards with that specific suit and number
    // [One Character For Suit]{}= disables all cards of chosen suit.
    // [Modifier Exact string] = disables cards with that modifier.
    public void SetPermissions(string[] perms, bool forPlayer, bool forEnemy)
    {
        foreach(string perm in perms)
        {
            switch(perm[0])
            {
                case 'C':
                    // Clubs
                    if(perm.Length > 1)
                    {
                        try
                        {
                            _playPermissionsCard[int.Parse(perm.Substring(1))]["C"] = new bool[2] { !forPlayer, !forEnemy };
                        }
                        catch (Exception)
                        {
                            //just do nothing
                        }
                    }
                    //All Clubs
                    else
                    {
                        for(int i = 6; i < 15; i++)
                        {
                            if (_playPermissionsCard.ContainsKey(i) && 
                                _playPermissionsCard[i].ContainsKey("C"))
                            {
                                _playPermissionsCard[i]["C"] = new bool[2] { !forPlayer, !forEnemy };
                            }
                        }
                    }
                    break;
                    
                case 'D':
                    // Diamonds
                    if(perm.Length > 1)
                    {
                        try
                        {
                            _playPermissionsCard[int.Parse(perm.Substring(1))]["D"] = new bool[2] { !forPlayer, !forEnemy };
                        }
                        catch (Exception)
                        {
                            //just do nothing
                        }
                    }
                    //All Diamonds
                    else
                    {
                        for(int i = 6; i < 15; i++)
                        {
                            if (_playPermissionsCard.ContainsKey(i) && 
                                _playPermissionsCard[i].ContainsKey("D"))
                            {
                                _playPermissionsCard[i]["D"] = new bool[2] { !forPlayer, !forEnemy };
                            }
                        }
                    }
                    break;
                    
                case 'H':
                    // Hearts
                    if(perm.Length > 1)
                    {
                        try
                        {
                            _playPermissionsCard[int.Parse(perm.Substring(1))]["H"] = new bool[2] { !forPlayer, !forEnemy };
                        }
                        catch (Exception)
                        {
                            //just do nothing
                        }
                    }
                    //All Hearts
                    else
                    {
                        for(int i = 6; i < 15; i++)
                        {
                            if (_playPermissionsCard.ContainsKey(i) && 
                                _playPermissionsCard[i].ContainsKey("H"))
                            {
                                _playPermissionsCard[i]["H"] = new bool[2] { !forPlayer, !forEnemy };
                            }
                        }
                    }
                    break;
                    
                case 'S':
                    // Spades
                    if(perm.Length > 1)
                    {
                        try
                        {
                            _playPermissionsCard[int.Parse(perm.Substring(1))]["S"] = new bool[2] { !forPlayer, !forEnemy };
                        }
                        catch (Exception)
                        {
                            //just do nothing
                        }
                    }
                    //all Spades
                    else
                    {
                        for(int i = 6; i < 15; i++)
                        {
                            if (_playPermissionsCard.ContainsKey(i) && 
                                _playPermissionsCard[i].ContainsKey("S"))
                            {
                                _playPermissionsCard[i]["S"] = new bool[2] { !forPlayer, !forEnemy };
                            }
                        }
                    }
                    break;
            }
            foreach (string modifier in CardInfo.modifierStringToType.Keys)
            {
                if(perm==modifier)
                {
                    _playPermissionsModifier[modifier]=new bool[2] { !forPlayer, !forEnemy };
                }
            }

        }
    }
}