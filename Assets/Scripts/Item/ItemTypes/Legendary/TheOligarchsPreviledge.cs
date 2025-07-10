using UnityEngine;
[CreateAssetMenu(fileName = "TheOligarchsPreviledge", menuName = "Items/Legendary/TheOligarchsPreviledge")]
public class TheOligarchsPreviledge : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.ItemId = "TheOligarchsPreviledge";
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._handSize += 2;
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {

    }

    public override void OnHeal(int amount)
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
