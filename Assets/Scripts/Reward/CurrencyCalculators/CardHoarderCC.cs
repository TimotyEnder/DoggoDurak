using UnityEngine;

public class CardHoarderCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        int cardsInDeck = GameHandler.Instance.GetGameState()._deck.Count;
        int calculation = 5 + Mathf.CeilToInt((cardsInDeck - 36) * 1f);
        return calculation;
    }

    public override string GetExplanationText()
    {
        return "From your hoarding habits: (Addicional cards:" + (GameHandler.Instance.GetGameState()._deck.Count - 36).ToString() + ") = ";
    }
}
