using UnityEngine;
[CreateAssetMenu(fileName = "DachaDoorstep", menuName = "Items/Common/DachaDoorstep")]
public class DachaDoorstep : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.ItemId = "DachaDoorstep";
    }

    public override void OnAquire()
    {
        for (int i = 0; i < 3; i++)
        {
            GameHandler.Instance.GetGameState()._deck[Random.Range(0, GameHandler.Instance.GetGameState()._deck.Count - 1)].addModifier("Bounce");
        }
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
    }

    public override void OnLoad()
    {
    }

    public override void OnPlayedCard(Card card)
    {
    }

    public override void OnReverse(Card card)
    {
    }
}
