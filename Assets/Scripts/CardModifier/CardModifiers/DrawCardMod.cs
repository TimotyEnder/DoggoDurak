using UnityEngine;

public class DrawCardMod : CardModifier
{
    public bool OnAquire()
    {
        return false;
    }

    public bool OnBeingDefended(Card cardDefendingThis)
    {
        return false;
    }

    public bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public bool OnPlayedCard(Card card)
    {
        GameHandler.Instance.Draw(1);
        return true;
    }

    public bool OnReverse(Card card)
    {
        return false;
    }
}
