using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasBorsh", menuName = "Items/Common/BabushkasBorsh")]
public class BabushkasBorsh : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "BabushkasBorsh";
        this.itemName = "BabushkasBorsh";
        this.toolTipDesc = "3 random cards gain "+StylisticClass.RestoringColor+StylisticClass.RestoringString+CardInfo.modifierToDescription["Restoring"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(3,"Restoring");
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
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
