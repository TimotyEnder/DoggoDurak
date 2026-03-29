using UnityEngine;
[CreateAssetMenu(fileName = "ContrabandCarePackage", menuName = "Items/Common/ContrabandCarePackage")]
public class ContrabandCarePackage : Item
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
        this.rarity = 0;
        this.boss = false;
        this.itemId = "ContrabandCarePackage";
        this.itemName="ContrabandCarePackage";
        this.toolTipDesc = "5 random cards gain "+StylisticClass.DrawColor+StylisticClass.DrawString+" 1 (Draws 1 card for each draw modifier on the card)</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(5,"Draw");
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
