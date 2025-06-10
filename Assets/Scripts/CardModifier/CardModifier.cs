using UnityEngine;

public interface CardModifier
{
    public void OnAquire();
    public void OnDefendCard(Card defendee, Card defended);
    public void OnPlayedCard(Card card);
    public void OnReverse(Card card);

}
