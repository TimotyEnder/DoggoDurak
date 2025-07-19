using UnityEngine;
[CreateAssetMenu(fileName = "TheOligarchsPreviledge", menuName = "Items/Legendary/TheOligarchsPreviledge")]
public class TheOligarchsPreviledge : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "TheOligarchsPreviledge";
        this.toolTipDesc = "+2 hand size";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._handSize += 2;
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
