using UnityEngine;

public class CardHoarderCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        int cardsInDeck = GameHandler.Instance.GetGameState()._deck.Count;
        int calculation = cardsInDeck / 10;
        return calculation;
    }

    public override string GetExplanationText()
    {
        return "Cards in deck: " + GameHandler.Instance.GetGameState()._deck.Count.ToString() + " = ";
    }
}
