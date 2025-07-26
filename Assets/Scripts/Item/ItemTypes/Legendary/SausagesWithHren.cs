using UnityEngine;
[CreateAssetMenu(fileName = "SausagesWithHren", menuName = "Items/Legendary/SausagesWithHren")]
public class SausagesWithHren : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "SausagesWithHren";
        this.toolTipDesc = "All cards in your deck gain Bounce(When defending, this card deals damage equal to the difference of values between the defending and defended cards)";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            c.AddModifier("Bounce");
        }
    }

    public override void OnDamageOpponent(int amount)
    {
        
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
