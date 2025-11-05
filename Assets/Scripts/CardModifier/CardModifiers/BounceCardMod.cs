using UnityEngine;

public class BounceCardMod : CardModifier
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
        if (!defendee.GetCardInfo()._opponentCard)
        {
            DelayedDamage(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number), false);
        }
        else 
        {
            DelayedDamage(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number), true);
        }
        return true;
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
