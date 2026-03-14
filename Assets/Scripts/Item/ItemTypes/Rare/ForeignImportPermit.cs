using UnityEngine;
[CreateAssetMenu(fileName = "ForeignImportPermit", menuName = "Items/Rare/ForeignImportPermit")]
class ForeignImportPermit : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "ForeignImportPermit";
        this.itemName="ForeignImportPermit";
        this.toolTipDesc = $"In encounter rewards you can select {StylisticClass.HighLight}1 more item{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._maxRewardChoices++;
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