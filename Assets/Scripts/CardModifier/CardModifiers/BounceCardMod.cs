using UnityEngine;

public class BounceCardMod : CardModifier
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
        if (!defendee.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
        }
        return true;
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
