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
        if (!card.GetCard()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(card.GetCard()._number);
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(card.GetCard()._number);
        }
    }
}
