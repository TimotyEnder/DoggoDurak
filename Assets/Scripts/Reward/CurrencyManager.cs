using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager
{
    private List<CurrencyCalculator> _currCurrencyCalculator;
    public CurrencyManager() 
    {
        _currCurrencyCalculator = new List<CurrencyCalculator>();
        _currCurrencyCalculator.Add(new DefaultCC());
    }
    public int GetCurrency() 
    {
        int total = 0;
        foreach (CurrencyCalculator c in _currCurrencyCalculator) 
        {
            total += c.CalculateCurrency();
        }
        return total;
    }
    public string GetCurrencyExplanationText() 
    {
        //implement later
        return null;
    }

}
