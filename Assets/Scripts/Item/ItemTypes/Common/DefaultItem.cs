using UnityEngine;
[CreateAssetMenu(fileName = "DefaultItem", menuName = "Items/Default")]
public class DefaultItem : Item
{
    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        itemId = "DefaultItem";
        this.toolTipDesc = "How the fuck are you seeing this?";
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
