using UnityEngine;

public class BurnCardMod : CardModifier
{
    public void OnAquire()
    {
    }

    public void OnDefendCard(Card defendee, Card defended)
    {
    }

    public void OnPlayedCard(Card card)
    {
        if (!card.GetCard()._opponentCard)
        {
            GameHandler.Instance.DamageOpponent(1); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
        else 
        {
            GameHandler.Instance.DamagePlayer(1); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
    }

    public void OnReverse(Card card)
    {
    }
}
