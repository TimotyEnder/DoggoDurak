using UnityEngine;
[CreateAssetMenu(fileName = "STsh81", menuName = "Items/Legendary/STsh81")]
class STsh81 : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "STsh81";
        this.itemName="STsh-81 Sfera";
        this.toolTipDesc = $"You recieve {StylisticClass.DamageNumber(3)} less from all sources.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._playedDamageReduction+=3;
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
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