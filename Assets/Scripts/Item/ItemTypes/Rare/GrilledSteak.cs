using UnityEngine;
[CreateAssetMenu(fileName = "GrilledSteak", menuName = "Items/Rare/GrilledSteak")]
public class GrilledSteak : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "GrilledSteak";
        this.toolTipDesc = "Doubles max health";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.IncreaseMaxHealth(GameHandler.Instance.GetGameState()._maxhealth *= 2);
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
