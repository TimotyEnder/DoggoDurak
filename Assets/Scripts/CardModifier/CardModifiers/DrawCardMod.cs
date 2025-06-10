using UnityEngine;

public class DrawCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {

    }

    public void OnPlayedCard(Card card)
    {
        GameHandler.Instance.Draw(1);
    }

    public void OnReverse(Card card)
    {

    }
}
