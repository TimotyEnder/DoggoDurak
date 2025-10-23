using UnityEngine;

public class Scaler : CurrencyCalculator
{
    float Modifier = 1.1f;
    public override int CalculateCurrency()
    {
        float calc = 5 * Modifier;
        Modifier += 0.1f;
        return (int)calc;
    }

    public override string GetExplanationText()
    {
        return "Scaler: 5 x" + Modifier.ToString("F2") + " = ";
    }
}
