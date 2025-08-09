using UnityEngine;

public class ParryCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnBeingDefended(Card cardDefendingThis)
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {

    }

    public void OnPlayedCard(Card card)
    {

    }

    public void OnReverse(Card card)
    {
        if (!card.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(card.GetCardInfo()._number);
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(card.GetCardInfo()._number);
        }
    }
}
