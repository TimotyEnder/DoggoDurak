using UnityEngine;

public class SpikyCardMod : CardModifier
{
    public bool OnAquire()
    {
        return false;
    }

    public bool OnBeingDefended(Card cardDefendingThis)
    {
        if (!cardDefendingThis.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamagePlayer(1);
        }
        else
        {
            GameHandler.Instance.DamageOpponent(1);
        }
        return true;
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
        return false;
    }
}
