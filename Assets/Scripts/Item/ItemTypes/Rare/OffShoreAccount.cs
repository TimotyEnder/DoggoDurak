using UnityEngine;
[CreateAssetMenu(fileName = "OffShoreAccount", menuName = "Items/Rare/OffShoreAccount")]
public class OffShoreAccount : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "OffshoreAccount";
        this.toolTipDesc = "You now gain an amount of rubles that increases with the amount of encounters played";
    }

    public override void OnActivate()
    {
    }

    public override void OnAquire()
    {
        GameHandler.Instance.AddCurrencyCalculator(new ScalerCC());
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