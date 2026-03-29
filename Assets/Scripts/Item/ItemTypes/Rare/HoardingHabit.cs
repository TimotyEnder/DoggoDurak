using UnityEngine;
[CreateAssetMenu(fileName = "HoardingHabit", menuName = "Items/Rare/HoardingHabit")]
public class HoardingHabit : Item
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "HoardingHabit";
        this.itemName="HoardingHabit";
        this.toolTipDesc = "For each encounter get a  ruble reward for each additional card in your deck";
    }

    public override void OnActivate()
    {
    }

    public override void OnAquire()
    {
        GameHandler.Instance.AddCurrencyCalculator(new CardHoarderCC());
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
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