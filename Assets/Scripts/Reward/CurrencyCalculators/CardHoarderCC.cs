using UnityEngine;

public class CardHoarderCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        int cardsInDeck = GameHandler.Instance.GetGameState()._deck.Count;
        int calculation =  Mathf.CeilToInt((cardsInDeck-36)*0.5f);
        return calculation;
    }

    public override string GetExplanationText()
    {
        return "A Check from the MMM: (Cards in Deck:" + GameHandler.Instance.GetGameState()._deck.Count.ToString() + ") = ";
    }
}
