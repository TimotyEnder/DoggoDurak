class InterestCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        return (int)(5+(0.1f*GameHandler.Instance.GetGameState()._rubles));
    }

    public override string GetExplanationText()
    {
        return $"Investment dividends: (5 x 20% of {GameHandler.Instance.GetGameState()._rubles}) = ";
    }
}