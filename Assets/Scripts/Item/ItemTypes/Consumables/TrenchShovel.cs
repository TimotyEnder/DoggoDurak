using UnityEngine;
[CreateAssetMenu(fileName = "TrenchShovel", menuName = "Items/Consumable/TrenchShovel")]
class TrenchShovel : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        isActive=true;
        persistent=true;
        consumable=true;
        itemId = "TrenchShovel";
        this.itemName="TrenchShovel";
        this.toolTipDesc = $"{StylisticClass.ConsumeString} Recieve {StylisticClass.DamageNumber(10)} less from all sources {StylisticClass.HighLight}this turn{StylisticClass.HighLightClose}.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.GetGameState()._playerDamageReduction+=10;
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
        GameHandler.Instance.GetGameState()._playerDamageReduction-=10;
    }
}