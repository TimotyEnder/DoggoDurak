using UnityEngine;

public class DefaultCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        return GameHandler.Instance.GetGameState()._encounter * ((GameHandler.Instance.GetGameState()._health) / GameHandler.Instance.GetGameState()._maxhealth)*20+1;
    }
}
