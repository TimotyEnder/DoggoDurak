using UnityEngine;

public class BounceCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnBeingDefended(Card cardDefendingThis)
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {
        if (!defendee.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number));
        }
    }

    public void OnPlayedCard(Card card)
    {

    }

    public void OnReverse(Card card)
    {

    }
}
