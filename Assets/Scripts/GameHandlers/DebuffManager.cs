using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework.Constraints;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine.InputSystem.Controls;

[Serializable]
public class DebuffManager 
{
    //number-> suit-> 0=player 1=enemy-> boolean representing if card can be played 
    public  Dictionary<string, Dictionary<int, bool[]>> _playPermissionsCard;
    public Dictionary<string, bool[]> _playPermissionsModifier;
    public bool[] AllEven;
    public bool[] AllOdd;
    public DebuffManager()
    {
        ResetPermissions();
    }
    public bool  CanPlayCard(CardInfo card, int target)
    {
        foreach (CardModifierContainer modifier in card._modifiers)
        {
            if (_playPermissionsModifier.ContainsKey(modifier.ModType))
            {
                if (!_playPermissionsModifier[modifier.ModType][target])
                {
                    return false;
                }
            }
        }
        if(!_playPermissionsCard.ContainsKey(card._suit)){return false;}
        else if(!AllEven[target] || !AllOdd[target]){return false;}
        else
        {
            return !_playPermissionsCard[card._suit].ContainsKey(card._number) || _playPermissionsCard[card._suit][card._number][target];
        }
    }
    public void ResetPermissions() 
    {
        _playPermissionsModifier= new Dictionary<string, bool[]>();
        foreach (string modifier in CardInfo.modifierStringToType.Keys)
        {
            _playPermissionsModifier[modifier] = new bool[2]{true, true};
        }
        _playPermissionsCard= new Dictionary<string, Dictionary<int, bool[]>>
        {
            { "C", new Dictionary<int, bool[]>() },
            { "D", new Dictionary<int, bool[]>() },
            { "S", new Dictionary<int, bool[]>() },
            { "H", new Dictionary<int, bool[]>() },
            { "L", new Dictionary<int, bool[]>() }
        };
        AllEven=new bool[2]{true, true};
        AllOdd=new bool[2]{true, true};
    }
    //how to use:
    // [One Character For Suit]{Number} = disables cards with that specific suit and number
    // [One Character For Suit]{}= disables all cards of chosen suit.
    // [Modifier Exact string] = disables cards with that modifier.
    public void SetPermissions(string[] perms, bool forPlayer, bool forEnemy,bool[] AllEven=null, bool[] AllOdd=null)
    {
        if(AllEven!=null)
        {
            this.AllEven=AllEven;
        }
        if(AllOdd!=null)
        {
            this.AllOdd = AllOdd;
        }
        foreach(string perm in perms)
        {
            switch(perm[0])
            {
                case 'C':
                    // Clubs
                    if(perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if(_playPermissionsCard.ContainsKey("C"))
                        {
                            if (_playPermissionsCard["C"].ContainsKey(num))
                            {
                                _playPermissionsCard["C"][num]= new bool[2]{forPlayer,forEnemy};
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        _playPermissionsCard.Remove("C");
                    }
                    break;
                    
                case 'D':
                    // Diamonds
                    if(perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if(_playPermissionsCard.ContainsKey("D"))
                        {
                            if (_playPermissionsCard["D"].ContainsKey(num))
                            {
                                _playPermissionsCard["D"][num]= new bool[2]{forPlayer,forEnemy};
                            }
                        }
                    }
                    //All Diamonds
                    else
                    {
                        _playPermissionsCard.Remove("D");
                    }
                    break;
                    
                case 'H':
                    // Hearts
                    if(perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if(_playPermissionsCard.ContainsKey("H"))
                        {
                            if (_playPermissionsCard["H"].ContainsKey(num))
                            {
                                _playPermissionsCard["H"][num]= new bool[2]{forPlayer,forEnemy};
                            }
                        }
                    }
                    //All Hearts
                    else
                    {
                       _playPermissionsCard.Remove("H");
                    }
                    break;
                case 'S':
                    // A spade
                    if(perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if(_playPermissionsCard.ContainsKey("S"))
                        {
                            if (_playPermissionsCard["S"].ContainsKey(num))
                            {
                                _playPermissionsCard["S"][num]= new bool[2]{forPlayer,forEnemy};
                            }
                        }
                    }
                    //all Spades
                    else
                    {
                        _playPermissionsCard.Remove("S");
                    }
                    break;
                case 'L':
                    // A laika
                    if(perm.Length > 1)
                        {
                            int num = int.Parse(perm.Substring(1));
                            if(_playPermissionsCard.ContainsKey("L"))
                            {
                                if (_playPermissionsCard["L"].ContainsKey(num))
                                {
                                    _playPermissionsCard["L"][num]= new bool[2]{forPlayer,forEnemy};
                                }
                            }
                        }
                    //all Laikas
                    else
                    {
                        _playPermissionsCard.Remove("L");
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