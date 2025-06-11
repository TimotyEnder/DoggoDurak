using UnityEngine;

public class CrippleCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnBeingDefended(Card cardDefendingThis)
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {

    }

    public void OnPlayedCard(Card card)
    {
        GameHandler.Instance.OpponentDiscard(1);
    }

    public void OnReverse(Card card)
    {

    }
}
