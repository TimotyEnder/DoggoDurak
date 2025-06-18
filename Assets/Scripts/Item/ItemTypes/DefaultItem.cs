using UnityEngine;
[CreateAssetMenu(fileName = "DefaulItem", menuName = "Items/Default")]
public class DefaultItem : Item
{
    public override void OnLoad()
    {
        rarity = 0;
        boss = false;
    }

    public override void OnAquire()
    {
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
    }

    public override void OnPlayedCard(Card card)
    {
    }

    public override void OnReverse(Card card)
    {
    }
}
