using UnityEngine;
[CreateAssetMenu(fileName = "SunfrowerSeedsBag", menuName = "Items/Rare/SunfrowerSeedsBag")]
class SunfrowerSeedsBag : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "SunfrowerSeedsBag";
        this.itemName="SunfrowerSeedsBag";
        this.toolTipDesc = $"Heal {StylisticClass.HighLight}2hp{StylisticClass.HighLightClose} at the {StylisticClass.HighLight}end of each turn{StylisticClass.HighLightClose}. This amount cannot be increased.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        
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
        GameHandler.Instance.HealPlayer(2,true);
    }
}