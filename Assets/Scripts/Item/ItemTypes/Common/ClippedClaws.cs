using UnityEngine;
[CreateAssetMenu(fileName = "DoggoSnack", menuName = "Items/Common/ClippedClaws")]
public class ClippedClaws : Item
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
        this.rarity = 0;
        this.boss = false;
        this.itemId = "ClippedClaws";
        this.itemName="ClippedClaws";
        this.toolTipDesc = "7 random cards gain "+StylisticClass.SpikyColor+StylisticClass.SpikyString+" 1"+CardInfo.modifierToDescription["Spiky"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(7,"Spiky");
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
