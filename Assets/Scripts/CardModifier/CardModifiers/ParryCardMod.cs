using UnityEngine;

public class ParryCardMod : CardModifier
{
    public bool OnAquire()
    {
        return false;
    }

    public bool OnBeingDefended(Card cardDefendingThis)
    {
        return false;
    }

    public bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public bool OnPlayedCard(Card card)
    {
        return false;
    }

    public bool OnReverse(Card card)
    {
        if (!card.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(card.GetCardInfo()._number);
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(card.GetCardInfo()._number);
        }
        return true;
    }
}
