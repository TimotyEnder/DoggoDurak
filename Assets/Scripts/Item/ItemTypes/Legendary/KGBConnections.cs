using UnityEngine;
[CreateAssetMenu(fileName = "KGBConnections", menuName = "Items/Legendary/KGBConnections")]
public class KGBConnections : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "KGBConnections";
        this.itemName="KGBConnections";
        this.toolTipDesc = $"All {StylisticClass.HighLight}face cards{StylisticClass.HighLightClose} gain "+StylisticClass.CrippleColor+StylisticClass.CrippleString+CardInfo.modifierToDescription["Cripple"]+"</color>";
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
                c.AddModifier("Cripple");
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
        if (card.IsFace()) 
        {
            card.AddModifier("Cripple");
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
