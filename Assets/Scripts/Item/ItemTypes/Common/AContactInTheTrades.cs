using UnityEngine;
[CreateAssetMenu(fileName = "AContactInTheTrades", menuName = "Items/Common/AContactInTheTrades")]
class AContactInTheTrades : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "AContactInTheTrades";
        this.itemName="AContactInTheTrades";
        this.toolTipDesc = $"+1 shop reroll in the shop tab.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._maxFreeShopRerolls++;
        GameHandler.Instance.GetGameState()._freeShopRerolls++;
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