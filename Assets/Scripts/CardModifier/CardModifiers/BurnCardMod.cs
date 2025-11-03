using UnityEngine;

public class BurnCardMod : CardModifier
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
        if (!card.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(1); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(1); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
        return true;
    }

    public bool OnReverse(Card card)
    {
        return false;
    }
}
