using UnityEngine;
[CreateAssetMenu(fileName = "RedStar", menuName = "Items/Boss/RedStar")]
public class RedStar : Item
{
    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.itemId = "RedStar";
        this.toolTipDesc = "Red cards are counted as the same suit";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._redCardsSameSuit = true;
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
