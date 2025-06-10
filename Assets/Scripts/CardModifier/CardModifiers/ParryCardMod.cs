using UnityEngine;

public class ParryCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {

    }

    public void OnPlayedCard(Card card)
    {

    }

    public void OnReverse(Card card)
    {
        GameHandler.Instance.Damage(card.GetCard()._number);
    }
}
