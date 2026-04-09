using System;
using System.Collections.Generic;

[Serializable]
public class DebuffManager
{
    //number-> suit-> 0=player 1=enemy-> boolean representing if card can be played 
    public Dictionary<string, Dictionary<int, Dictionary<int, bool>>> _playPermissionsCard;
    public Dictionary<string, bool[]> _playPermissionsModifier;
    public bool[] AllEvenDebuffed;
    public bool[] AllOdd;
    public DebuffManager()
    {
        ResetPermissions();
    }
    public bool CanPlayCard(CardInfo card, int target)
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
        if (!_playPermissionsCard[card._suit].ContainsKey(target)) { return false; }
        else if (AllEvenDebuffed[target] && card.IsEven() || AllOdd[target] && card.IsOdd()) { return false; }
        else
        {
            return !_playPermissionsCard[card._suit][target].ContainsKey(card._number) || !_playPermissionsCard[card._suit][target][card._number];
        }
    }
    public void ResetPermissions()
    {
        _playPermissionsModifier = new Dictionary<string, bool[]>();
        foreach (string modifier in CardInfo.modifierStringToType.Keys)
        {
            _playPermissionsModifier[modifier] = new bool[2] { true, true };
        }

        _playPermissionsCard = new Dictionary<string, Dictionary<int, Dictionary<int, bool>>>();

        string[] suits = { "C", "D", "S", "H", "L" };
        foreach (string suit in suits)
        {
            _playPermissionsCard[suit] = new Dictionary<int, Dictionary<int, bool>>();
            _playPermissionsCard[suit].Add(0, new Dictionary<int, bool>());
            _playPermissionsCard[suit].Add(1, new Dictionary<int, bool>());

        }

        AllEvenDebuffed = new bool[2] { false, false };
        AllOdd = new bool[2] { false, false };
    }
    //how to use:
    // [One Character For Suit]{Number} = disables cards with that specific suit and number
    // [One Character For Suit]{}= disables all cards of chosen suit.
    // [Modifier Exact string] = disables cards with that modifier.
    public void SetPermissions(string[] perms, bool forPlayer, bool forEnemy, bool[] AllEven = null, bool[] AllOdd = null)
    {
        if (AllEven != null)
        {
            this.AllEvenDebuffed = AllEven;
        }
        if (AllOdd != null)
        {
            this.AllOdd = AllOdd;
        }
        if (perms == null) { return; }
        foreach (string perm in perms)
        {
            switch (perm[0])
            {
                case 'C':
                    // Clubs
                    if (perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if (_playPermissionsCard.ContainsKey("C"))
                        {
                            if (_playPermissionsCard["C"].ContainsKey(num))
                            {
                                if (!_playPermissionsCard["C"][num].ContainsKey(0))
                                {
                                    _playPermissionsCard["C"][num].Add(0, forPlayer);
                                }
                                else
                                {
                                    _playPermissionsCard["C"][num][0] = forPlayer;
                                }
                                if (!_playPermissionsCard["C"][num].ContainsKey(1))
                                {
                                    _playPermissionsCard["C"][num].Add(1, forEnemy);
                                }
                                else
                                {
                                    _playPermissionsCard["C"][num][0] = forEnemy;
                                }

                            }
                            else
                            {
                                _playPermissionsCard["C"].Add(num, new Dictionary<int, bool>());
                                _playPermissionsCard["C"][num].Add(0, forPlayer);
                                _playPermissionsCard["C"][num].Add(1, forEnemy);
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        if (forPlayer)
                        {
                            _playPermissionsCard["C"].Remove(0);
                        }
                        if (forEnemy)
                        {
                            _playPermissionsCard["C"].Remove(1);
                        }
                    }
                    break;

                case 'D':
                    // Diamonds
                    if (perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if (_playPermissionsCard.ContainsKey("D"))
                        {
                            if (_playPermissionsCard["D"].ContainsKey(num))
                            {
                                if (!_playPermissionsCard["D"][num].ContainsKey(0))
                                {
                                    _playPermissionsCard["D"][num].Add(0, forPlayer);
                                }
                                else
                                {
                                    _playPermissionsCard["D"][num][0] = forPlayer;
                                }
                                if (!_playPermissionsCard["D"][num].ContainsKey(1))
                                {
                                    _playPermissionsCard["D"][num].Add(1, forEnemy);
                                }
                                else
                                {
                                    _playPermissionsCard["D"][num][0] = forEnemy;
                                }

                            }
                            else
                            {
                                _playPermissionsCard["D"].Add(num, new Dictionary<int, bool>());
                                _playPermissionsCard["D"][num].Add(0, forPlayer);
                                _playPermissionsCard["D"][num].Add(1, forEnemy);
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        if (forPlayer)
                        {
                            _playPermissionsCard["D"].Remove(0);
                        }
                        if (forEnemy)
                        {
                            _playPermissionsCard["D"].Remove(1);
                        }
                    }
                    break;
                case 'H':
                    // Hearts
                    if (perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if (_playPermissionsCard.ContainsKey("H"))
                        {
                            if (_playPermissionsCard["H"].ContainsKey(num))
                            {
                                if (!_playPermissionsCard["H"][num].ContainsKey(0))
                                {
                                    _playPermissionsCard["H"][num].Add(0, forPlayer);
                                }
                                else
                                {
                                    _playPermissionsCard["H"][num][0] = forPlayer;
                                }
                                if (!_playPermissionsCard["H"][num].ContainsKey(1))
                                {
                                    _playPermissionsCard["H"][num].Add(1, forEnemy);
                                }
                                else
                                {
                                    _playPermissionsCard["H"][num][0] = forEnemy;
                                }

                            }
                            else
                            {
                                _playPermissionsCard["H"].Add(num, new Dictionary<int, bool>());
                                _playPermissionsCard["H"][num].Add(0, forPlayer);
                                _playPermissionsCard["H"][num].Add(1, forEnemy);
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        if (forPlayer)
                        {
                            _playPermissionsCard["H"].Remove(0);
                        }
                        if (forEnemy)
                        {
                            _playPermissionsCard["H"].Remove(1);
                        }
                    }
                    break;
                case 'S':
                    // A spade
                    if (perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if (_playPermissionsCard.ContainsKey("S"))
                        {
                            if (_playPermissionsCard["S"].ContainsKey(num))
                            {
                                if (!_playPermissionsCard["S"][num].ContainsKey(0))
                                {
                                    _playPermissionsCard["S"][num].Add(0, forPlayer);
                                }
                                else
                                {
                                    _playPermissionsCard["S"][num][0] = forPlayer;
                                }
                                if (!_playPermissionsCard["S"][num].ContainsKey(1))
                                {
                                    _playPermissionsCard["S"][num].Add(1, forEnemy);
                                }
                                else
                                {
                                    _playPermissionsCard["S"][num][0] = forEnemy;
                                }

                            }
                            else
                            {
                                _playPermissionsCard["S"].Add(num, new Dictionary<int, bool>());
                                _playPermissionsCard["S"][num].Add(0, forPlayer);
                                _playPermissionsCard["S"][num].Add(1, forEnemy);
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        if (forPlayer)
                        {
                            _playPermissionsCard["S"].Remove(0);
                        }
                        if (forEnemy)
                        {
                            _playPermissionsCard["S"].Remove(1);
                        }
                    }
                    break;
                case 'L':
                    // A laika
                    if (perm.Length > 1)
                    {
                        int num = int.Parse(perm.Substring(1));
                        if (_playPermissionsCard.ContainsKey("L"))
                        {
                            if (_playPermissionsCard["L"].ContainsKey(num))
                            {
                                if (!_playPermissionsCard["L"][num].ContainsKey(0))
                                {
                                    _playPermissionsCard["L"][num].Add(0, forPlayer);
                                }
                                else
                                {
                                    _playPermissionsCard["L"][num][0] = forPlayer;
                                }
                                if (!_playPermissionsCard["L"][num].ContainsKey(1))
                                {
                                    _playPermissionsCard["L"][num].Add(1, forEnemy);
                                }
                                else
                                {
                                    _playPermissionsCard["L"][num][0] = forEnemy;
                                }

                            }
                            else
                            {
                                _playPermissionsCard["L"].Add(num, new Dictionary<int, bool>());
                                _playPermissionsCard["L"][num].Add(0, forPlayer);
                                _playPermissionsCard["L"][num].Add(1, forEnemy);
                            }
                        }
                    }
                    //All Clubs
                    else
                    {
                        if (forPlayer)
                        {
                            _playPermissionsCard["L"].Remove(0);
                        }
                        if (forEnemy)
                        {
                            _playPermissionsCard["L"].Remove(1);
                        }
                    }
                    break;
            }
            foreach (string modifier in CardInfo.modifierStringToType.Keys)
            {
                if (perm == modifier)
                {
                    _playPermissionsModifier[modifier] = new bool[2] { !forPlayer, !forEnemy };
                }
            }

        }
    }
}
