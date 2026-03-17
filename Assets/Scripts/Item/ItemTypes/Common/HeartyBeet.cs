using UnityEngine;
[CreateAssetMenu(fileName = "HeartyBeet", menuName = "Items/Common/HeartyBeet")]
class HeartyBeet : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "HeartyBeet";
        this.itemName="HeartyBeet";
        this.toolTipDesc = "+1 to 15 random cards.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        UpgradeRandomCards(15,1);
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
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