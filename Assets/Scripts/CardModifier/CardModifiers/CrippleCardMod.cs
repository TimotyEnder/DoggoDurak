using UnityEngine;

public class CrippleCardMod : CardModifier
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
        if(card.GetCardInfo()._opponentCard)
        {
            GameHandler.Instance.PlayerDiscard(Random.Range(0,GameHandler.Instance.GetPlayerCardsInHand()-1),1);
        }
        else
        {
            GameHandler.Instance.OpponentDiscard(1);
        }
        return true;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}
