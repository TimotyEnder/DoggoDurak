using UnityEngine;
[CreateAssetMenu(fileName = "HotChocolate", menuName = "Items/Legendary/HotChocolate")]
class HotChocolate : Item
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
        this.rarity = 2;
        this.boss = false;
        this.itemId = "HotChocolate";
        this.itemName="HotChocolate";
        this.toolTipDesc = $"Your {StylisticClass.BurnColor}{StylisticClass.BurnString}</color> modifiers also apply {StylisticClass.HighLight}poison counters{StylisticClass.HighLightClose}.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._burnPoison=true;
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