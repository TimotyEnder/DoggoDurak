using UnityEngine;
[CreateAssetMenu(fileName = "TsarsCrown", menuName = "Items/Rare/TsarsCrown")]
public class TsarsCrown:Item
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
        this.itemId = "TsarsCrown";
        this.itemName="TsarsCrown";
        this.toolTipDesc = $"All {StylisticClass.HighLight}face{StylisticClass.HighLightClose} cards are {StylisticClass.HighLight}Kings{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c.IsFace()) 
            {
                c._number=13;
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
        if (card.IsFace()) 
        {
            card._number=13;
        }
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
