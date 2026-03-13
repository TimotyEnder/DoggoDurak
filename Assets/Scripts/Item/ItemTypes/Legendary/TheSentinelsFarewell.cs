using UnityEngine;
[CreateAssetMenu(fileName = "TheSentinelsFarewell", menuName = "Items/Active-Legendary/TheSentinelsFarewell")]
public class TheSentinelsFarewell : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.persistent=true;
        this.itemId = "TheSentinelsFarewell";
        this.itemName="TheSentinel'sFarewell";
        this.toolTipDesc =StylisticClass.ActivateString+" set your hp to 1, it cannot be lowered this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetHealth(1);
        GameHandler.Instance.GetGameState()._undamagable[0]=true;
    }

    public override void OnAquire()
    {

    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {

    }

    public override void OnDefendCard(Card defendee, Card defended)
    {

    }

    public override void OnEncounterStart()
    {
        
    }

    public override void OnEndEncounter()
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

    public override void OnTurnEnd(int turnState)
    {
        
    }
}