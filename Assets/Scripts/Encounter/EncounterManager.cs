using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EncounterManager
{
    private List<List<Encounter>> _encounters;
    private List<Encounter> _bossEncounters;
    public EncounterManager() 
    {
        _encounters= new List<List<Encounter>>();
        _bossEncounters= new List<Encounter>();
        var loadedEncounters = Resources.LoadAll<Encounter>("Encounters");
        foreach(var e in loadedEncounters) 
        {
            e.InitEncounter();
            if (!e.IsBoss())
            {
                while (e.GetDay() >= _encounters.Count)
                {
                    _encounters.Add(new List<Encounter>());
                }
                _encounters[e.GetDay()].Add(e);
            }
            else 
            {
                _bossEncounters.Add(e);
            }
        }
    }
    public Encounter RandomEncounter(int day) 
    {
        if (day < _encounters.Count && _encounters[day].Count>0) 
        {
            return _encounters[day][Random.Range(0, _encounters[day].Count)]; 
        }
        return null;
    }
    public Encounter RandomBossEncounter() 
    {
        if (_bossEncounters.Count > 0) 
        {
            return _bossEncounters[Random.Range(0, _bossEncounters.Count)];
        }
        return null;
    }
}
