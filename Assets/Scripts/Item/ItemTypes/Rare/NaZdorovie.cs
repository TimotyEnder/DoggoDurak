using UnityEngine;
[CreateAssetMenu(fileName = "NaZdorovie", menuName = "Items/Rare/NaZdorovie")]
class NaZdorovie : Item
{
    public override int AddToDamageOpponent(int amount)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "NaZdorovie";
        this.itemName="Na zdorovie!";
        this.toolTipDesc = $"For each encounter, gain rubles based on {StylisticClass.HighLight}health lost/gained{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        GameHandler.Instance.AddCurrencyCalculator(new LifeGainCC());
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