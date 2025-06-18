using UnityEngine;
[CreateAssetMenu(fileName = "DefaulItem", menuName = "Items/Default")]
public class DefaultItem : Item
{
    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        ItemId = "DefaulItem";
    }
    public override void OnLoad()
    {

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
