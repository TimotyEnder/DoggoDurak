using UnityEngine;
[CreateAssetMenu(fileName = "DefaultItem", menuName = "Items/Default")]
public class DefaultItem : Item
{
    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        itemId = "DefaultItem";
        this.toolTipDesc = "Hello Modders! Have your fun! Sorry shit might be a bit confusing but i am sur you will figure it out:)";
    }
    public override void OnLoad()
    {

    }

    public override void OnAquire()
    {
        Debug.Log("Default Item On Aquire");
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

    public override void OnHeal(int amount)
    {

    }

    public override void OnDamageOpponent(int amount)
    {

    }

    public override void OnActivate()
    {

    }
}
