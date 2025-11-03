using UnityEngine;

public interface CardModifier
{
    public bool OnAquire();
    public bool OnDefendCard(Card defendee, Card defended);
    public bool OnPlayedCard(Card card);
    public bool OnReverse(Card card);
    public bool OnBeingDefended(Card cardDefendingThis);

}
