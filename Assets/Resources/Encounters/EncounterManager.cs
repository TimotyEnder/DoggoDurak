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
        var loadedEncounters = Resources.LoadAll<Encounter>("Encounters");
        foreach(var e in loadedEncounters) 
        {

            if (!e.isBoss())
            {
                while (e.GetDay() > _encounters.Count)
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
    public 
}
