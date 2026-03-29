using UnityEngine;
[CreateAssetMenu(fileName = "SiberianBearHuntingSuit", menuName = "Items/Rare/SiberianBearHuntingSuit")]
public class SiberianBearHuntingSuit : Item
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
        this.itemId = "SiberianBearHuntingSuit";
        this.itemName="SiberianBearHuntingSuit";
        this.toolTipDesc = $"{StylisticClass.SpikyColor}{StylisticClass.SpikyString}</color> effects +{StylisticClass.DamageNumber(1)}";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._modifierAddedEffect["Spiky"]++;
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
