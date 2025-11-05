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
        return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        GameHandler.Instance.Draw(1);
        return true;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}
