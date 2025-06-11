using UnityEngine;

public class SpikyCardMod : CardModifier
{
    public void OnAquire()
    {
    }

    public void OnBeingDefended(Card cardDefendingThis)
    {
        if (!cardDefendingThis.GetCard()._opponentCard)
        {
            GameHandler.Instance.DamagePlayer(1);
        }
        else
        {
            GameHandler.Instance.DamageOpponent(1);
        }
    }

    public void OnDefendCard(Card defendee, Card defended)
    {

    }

    public void OnPlayedCard(Card card)
    {
    }

    public void OnReverse(Card card)
    {
    }
}
