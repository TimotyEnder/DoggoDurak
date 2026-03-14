using UnityEngine;

public class DrawCardMod : CardModifier
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
         if(defendee.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.OpponentDraw(1);
        }
        else
        {
            GameHandler.Instance.Draw(1);
        }
        return true;
    }

    public override bool OnPlayedCard(Card card)
    {
        if(card.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.OpponentDraw(1);
        }
        else
        {
            GameHandler.Instance.Draw(1);
        }
        return true;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}
