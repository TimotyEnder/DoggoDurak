class InterestCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        return (int)(5*(0.3f*GameHandler.Instance.GetGameState()._rubles));
    }

    public override string GetExplanationText()
    {
        return $"Investment dividends: (5 x 20% {GameHandler.Instance.GetGameState()._rubles}) = ";
    }
}