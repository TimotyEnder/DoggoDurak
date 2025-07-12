using UnityEngine;
[CreateAssetMenu(fileName = "BlackStar", menuName = "Items/Boss/BlackStar")]
public class BlackStar : Item
{
    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.ItemId = "BlackStar";
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._blackCardsSameSuit = true;
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
