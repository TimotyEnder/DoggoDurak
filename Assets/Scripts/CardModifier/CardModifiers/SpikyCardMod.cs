using UnityEngine;

public class SpikyCardMod : CardModifier
{
    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnBeingDefended(Card cardDefendingThis)
    {
        if (!cardDefendingThis.GetCardInfo()._opponentCard)
        {
            DelayedDamage(1,false, "Spiky");
        }
        else
        {
            DelayedDamage(1,true, "Spiky");
        }
        return true;
    }

    public override bool OnCardDamage(int amount, Card card, int turnState)
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
        return false;
    }
}
