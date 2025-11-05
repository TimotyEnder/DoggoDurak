using UnityEngine;

public class ParryCardMod : CardModifier
{
    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnBeingDefended(Card cardDefendingThis)
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        return false;
    }

    public override bool OnReverse(Card card)
    {
        if (!card.GetCardInfo()._opponentCard)
        {
            DelayedDamage(card.GetCardInfo()._number, false);
        }
        else 
        {
            DelayedDamage(card.GetCardInfo()._number, true);
        }
        return true;
    }
}
