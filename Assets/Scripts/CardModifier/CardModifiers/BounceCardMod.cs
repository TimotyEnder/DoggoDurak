using UnityEngine;

public class BounceCardMod : CardModifier
{
    public void OnAquire()
    {

    }

    public void OnDefendCard(Card defendee, Card defended)
    {
        GameHandler.Instance.Damage(Mathf.Abs(defendee.GetCard()._number - defended.GetCard()._number));
    }

    public void OnPlayedCard(Card card)
    {

    }

    public void OnReverse(Card card)
    {

    }
}
