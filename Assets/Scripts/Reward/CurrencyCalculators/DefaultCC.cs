using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class DefaultCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        float calculation = 10 * ((float)(GameHandler.Instance.GetGameState()._health) / GameHandler.Instance.GetGameState()._maxhealth);
        return (int)calculation;
    }
}
