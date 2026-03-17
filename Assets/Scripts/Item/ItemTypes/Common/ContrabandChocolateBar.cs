using UnityEngine;
[CreateAssetMenu(fileName = "ContrabandChocolateBar", menuName = "Items/Common/ContrabandChocolateBar")]
class ContrabandChocolateBar : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "ContrabandChocolateBar";
        this.itemName="ContrabandChocolateBar";
        this.toolTipDesc = "5 random cards gain "+StylisticClass.PoisonColor+StylisticClass.PoisonString+" 1"+CardInfo.modifierToDescription["Poison"]+"</color>";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        AddModToRandomCards(5,"Poison");
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