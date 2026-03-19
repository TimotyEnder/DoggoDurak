using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GadalkaEffectManager
{
    private List<GadalkaEffectInfo> _curses;
    private List<GadalkaEffectInfo> _blessings;
    public GadalkaEffectManager()
    {
        _curses = new List<GadalkaEffectInfo>();
        _blessings= new List<GadalkaEffectInfo>();
        var loadedItems = Resources.LoadAll<GadalkaEffectInfo>("GadalkaEffects");
        foreach (var i in loadedItems)
        {
            GadalkaEffectInfo runtimeEffect = Object.Instantiate(i); // Create a safe copy
            runtimeEffect.InitEffect();
            if(runtimeEffect.IsBlessing())
            {
                _blessings.Add(runtimeEffect);
            }
            else
            {
                _curses.Add(runtimeEffect);
            }
        }
    }
    public List<GadalkaEffectInfo> BlessingCompile(int amount)
    {
        List<GadalkaEffectInfo> effectsDroppped = new List<GadalkaEffectInfo>();
        if(_blessings.Count>0)
        {
            int[] randomInts = RandomPlus.GenerateUniqueRandomNumbers(0, _blessings.Count - 1, amount);
            foreach (int i in randomInts)
            {
                GadalkaEffectInfo effectReturned = Object.Instantiate(_blessings[i]);
                effectReturned.InitEffect();
                effectsDroppped.Add(effectReturned);
            }
        }
        return effectsDroppped;
    }
    public List<GadalkaEffectInfo> CursesCompile(int amount)
    {
        List<GadalkaEffectInfo> effectsDroppped = new List<GadalkaEffectInfo>();
        if(_curses.Count>0)
        {
            int[] randomInts = RandomPlus.GenerateUniqueRandomNumbers(0, _curses.Count - 1, amount);
            foreach (int i in randomInts)
            {
                GadalkaEffectInfo effectReturned = Object.Instantiate(_curses[i]);
                effectReturned.InitEffect();
                effectsDroppped.Add(effectReturned);
            }
        }
        return effectsDroppped;
    }
    
}
