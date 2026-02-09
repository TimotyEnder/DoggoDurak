using UnityEngine;

public class ScalerCC : CurrencyCalculator
{
    float Modifier = 1.0f;
    public override int CalculateCurrency()
    {
        float calc = 2 * Modifier;
        Modifier += 0.1f;
        return (int)calc;
    }

    public override string GetExplanationText()
    {
        return "Scaler: 5 x" + Modifier.ToString("F2") + " = ";
    }
}
