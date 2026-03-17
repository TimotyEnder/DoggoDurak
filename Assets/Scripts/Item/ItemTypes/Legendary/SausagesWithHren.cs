using UnityEngine;
[CreateAssetMenu(fileName = "SausagesWithHren", menuName = "Items/Legendary/SausagesWithHren")]
public class SausagesWithHren : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "SausagesWithHren";
        this.itemName="SausagesWithHren";
        this.toolTipDesc = $"All {StylisticClass.HighLight}red{StylisticClass.HighLightClose} cards in your deck gain "+StylisticClass.BounceColor+StylisticClass.BounceString+CardInfo.modifierToDescription["Bounce"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if(c.IsRed())
            {
                c.AddModifier("Bounce");
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
        if(card.IsRed())
        {
            card.AddModifier("Bounce");
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
