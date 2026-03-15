using UnityEngine;
[CreateAssetMenu(fileName = "OligarchsProtection", menuName = "Items/Boss/OligarchsProtection")]
class OligarchsProtection : Item
{
    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.itemId = "OligarchsProtection";
        this.itemName="Oligarch's Protection";
        this.toolTipDesc = $"You {StylisticClass.HighLight}cannot reverse{StylisticClass.HighLightClose} and {StylisticClass.HighLight}cannot be reversed{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._reversePossible=false;
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