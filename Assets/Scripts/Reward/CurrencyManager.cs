using UnityEngine;

public class CurrencyManager
{
    private CurrencyCalculator _currCurrencyCalculator;
    public CurrencyManager() 
    {
        _currCurrencyCalculator = new DefaultCC();
    }
    public int GetCurrency() 
    {
        return _currCurrencyCalculator.CalculateCurrency();
    }
}
