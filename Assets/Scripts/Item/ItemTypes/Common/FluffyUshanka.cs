using UnityEngine;
[CreateAssetMenu(fileName = "FluffyUshanka", menuName = "Items/Common/FluffyUshanka")]
public class FluffyUshanka : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.ItemId = "FluffyUshanka";
    }

    public override void OnAquire()
    {

    }

    public override void OnDamageOpponent(int amount)
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {

    }

    public override void OnHeal(int amount)
    {
        GameHandler.Instance.HealPlayer(5);
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
