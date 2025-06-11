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
        if (!defendee.GetCard()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
        }
    }

    public void OnPlayedCard(Card card)
    {

    }

    public void OnReverse(Card card)
    {

    }
}
