using UnityEngine;

[CreateAssetMenu(
    fileName = "TheSentinelsFarewell",
    menuName = "Items/Active-Legendary/TheSentinelsFarewell"
)]
public class TheSentinelsFarewell : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive = true;
        this.persistent = true;
        this.itemId = "TheSentinelsFarewell";
        this.itemName = "TheSentinel'sFarewell";
        this.toolTipDesc =
            StylisticClass.ActivateString + " set your hp to 1, it cannot be lowered this turn.";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.SetHealth(1);
        GameHandler.Instance.GetGameState()._undamagable[0] = true;
        return true;
    }

    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
    {
        return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod = "")
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnDrawCard(CardInfo card)
    {
        return false;
    }

    public override bool OnEncounterStart()
    {
        return false;
    }

    public override bool OnEndEncounter()
    {
        return false;
    }

    public override bool OnHeal(int amount)
    {
        return false;
    }

    public override bool OnLoad()
    {
        return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        return false;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
        return false;
    }
}
