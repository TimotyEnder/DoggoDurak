using UnityEngine;

public class RestoringCardMod : CardModifier
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
            DelayedHeal(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number),true);
        }
        else 
        {
            DelayedHeal(Mathf.Abs(defendee.GetCardInfo()._number - defended.GetCardInfo()._number),false);
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
