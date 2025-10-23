using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class DefaultCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        float calculation = (100- (GameHandler.Instance.GetGameState()._lastHealth-GameHandler.Instance.GetGameState()._health))/10;
        return (int)calculation;
    }

    public override string GetExplanationText()
    {
        return "Health lost: " + (GameHandler.Instance.GetGameState()._lastHealth - GameHandler.Instance.GetGameState()._health).ToString()+" = ";
    }
}
