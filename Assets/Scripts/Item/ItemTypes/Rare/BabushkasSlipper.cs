using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasSlipper", menuName = "Items/Rare/BabushkasSlipper")]
public class BabushkasSlipper : Item
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
        this.itemId = "BabushkasSlipper";
        this.itemName="Babushka's Slipper";
        this.toolTipDesc = $"{StylisticClass.ParryColor}{StylisticClass.ParryString}</color> effects +{StylisticClass.DamageNumber(1)}";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._modifierAddedEffect["Parry"]++;
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
