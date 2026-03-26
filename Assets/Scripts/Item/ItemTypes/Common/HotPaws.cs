using UnityEngine;
[CreateAssetMenu(fileName = "DoggoSnack", menuName = "Items/Common/HotPaws")]
public class HotPaws : Item
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
        this.itemId = "HotPaws";
        this.itemName="HotPaws";
        this.toolTipDesc = "7 random cards gain "+StylisticClass.BurnColor+StylisticClass.BurnString+" 1"+CardInfo.modifierToDescription["Burn"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(7,"Burn");
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
