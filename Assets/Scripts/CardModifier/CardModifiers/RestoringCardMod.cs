using UnityEngine;

public class RestoringCardMod : CardModifier
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
            GameHandler.Instance.HealPlayer(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
        }
        else 
        {
            GameHandler.Instance.HealOpponent(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
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
