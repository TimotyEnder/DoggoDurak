using UnityEngine;

public class BurnCardMod : CardModifier
{
    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnBeingDefended(Card cardDefendingThis)
    {
        return false;
    }

    public override bool OnCardDamage(int amount, Card card, int turnState)
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        if (!defendee.GetCardInfo()._opponentCard)
        {
            DelayedDamage(1, false, "Burn"); //treat x = 1 for all X effects and just add more to a cards effect list.
            if(GameHandler.Instance.GetGameState()._burnPoison)
            {
                GameHandler.Instance.PoisonOpponent(1);
            }
        }
        else 
        {
            DelayedDamage(1, true, "Burn"); //treat x = 1 for all X effects and just add more to a cards effect list.
            if(GameHandler.Instance.GetGameState()._burnPoison)
            {
                GameHandler.Instance.PoisonPlayer(1);
            }
        }
        return true;
    }

    public override bool OnPlayedCard(Card card)
    {
        if (!card.GetCardInfo()._opponentCard)
        {
            DelayedDamage(1, false, "Burn"); //treat x = 1 for all X effects and just add more to a cards effect list.
            if(GameHandler.Instance.GetGameState()._burnPoison)
            {
                GameHandler.Instance.PoisonOpponent(1);
            }
        }
        else 
        {
            DelayedDamage(1, true, "Burn"); //treat x = 1 for all X effects and just add more to a cards effect list.
            if(GameHandler.Instance.GetGameState()._burnPoison)
            {
                GameHandler.Instance.PoisonPlayer(1);
            }
        }
        return true;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}
