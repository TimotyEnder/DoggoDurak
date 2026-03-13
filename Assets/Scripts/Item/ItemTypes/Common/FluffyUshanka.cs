using UnityEngine;
[CreateAssetMenu(fileName = "FluffyUshanka", menuName = "Items/Common/FluffyUshanka")]
public class FluffyUshanka : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "FluffyUshanka";
        this.itemName="FluffyUshanka";
        this.toolTipDesc = "Every time you heal, heal 5 more health";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {

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
        GameHandler.Instance.HealPlayer(5,true);
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
