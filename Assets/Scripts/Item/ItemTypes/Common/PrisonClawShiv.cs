using UnityEngine;
[CreateAssetMenu(fileName = "PrisonClawShiv", menuName = "Items/Common/PrisonClawShiv")]
public class PrisonClawShiv : Item
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
        this.itemId = "PrisonClawShiv";
        this.itemName="PrisonClawShiv";
        this.toolTipDesc = "5 random cards gain "+StylisticClass.ParryColor+StylisticClass.ParryString+" 1"+CardInfo.modifierToDescription["Parry"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(5,"Parry");
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
