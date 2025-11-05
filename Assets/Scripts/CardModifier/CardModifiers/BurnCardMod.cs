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

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        if (!card.GetCardInfo()._opponentCard)
        {
            DelayedDamage(1, false); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
        else 
        {
            DelayedDamage(1, true); //treat x = 1 for all X effects and just add more to a cards effect list.
        }
        return true;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}
