using UnityEngine;
[CreateAssetMenu(fileName = "TheSentinel'sFarewell", menuName = "Items/Active-Legendary/TheSentinel'sFarewell")]
public class TheSentinelsFarewell : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.persistent=true;
        this.itemId = "TheSentinel'sFarewell";
        this.toolTipDesc =StylisticClass.ActivateString+" set your hp to 1, it cannot be lowered this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SentinelsFarewell();
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