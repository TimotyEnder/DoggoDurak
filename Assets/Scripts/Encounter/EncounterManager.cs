using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EncounterManager
{
    private List<List<Encounter>> _encounters;
    private List<List<Encounter>> _bossEncounters;
    public EncounterManager() 
    {
        _encounters= new List<List<Encounter>>();
        _bossEncounters= new  List<List<Encounter>>();
        var loadedEncounters = Resources.LoadAll<Encounter>("Encounters");
        foreach(var e in loadedEncounters) 
        {
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
                while (e.GetDay() >= _bossEncounters.Count)
                {
                    _bossEncounters.Add(new List<Encounter>());
                }
                _bossEncounters[e.GetDay()].Add(e);
            }
        }
    }
    public Encounter RandomEncounter(int day) 
    {
        if (day < _encounters.Count && _encounters[day].Count>0) 
        {
            int roll= Random.Range(0, _encounters[day].Count);
            Encounter chosen = _encounters[day][roll];
            _encounters[day].Remove(chosen);
            chosen.InitiateEncounter();
            return chosen;
        }
        return null;
    }
    public Encounter RandomBossEncounter(int day) 
    {
        if (day < _bossEncounters.Count && _bossEncounters[day].Count>0) 
        {
            int roll= Random.Range(0, _bossEncounters[day].Count);
            Encounter chosen = _bossEncounters[day][roll];
            _bossEncounters[day].Remove(chosen);
            chosen.InitiateEncounter();
            return chosen;
        }
        return null;
    }
    public Encounter EncounterByName(string id)
    {
        // Search all normal encounters
        var allEncounters = _encounters.SelectMany(dayList => dayList);
        
        // Also include boss encounters
        allEncounters = allEncounters.Concat(_bossEncounters.SelectMany(dayList => dayList));
        Encounter toRet=allEncounters.LastOrDefault(encounter => encounter.GetEncounterName() == id);

        toRet.InitiateEncounter();
        if(toRet.IsBoss())
        {
            _bossEncounters[toRet.GetDay()].Remove(toRet);
        }
        else
        {
            _encounters[toRet.GetDay()].Remove(toRet);
        }
        return toRet;
    }
}