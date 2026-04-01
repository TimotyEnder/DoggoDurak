using UnityEngine;
[CreateAssetMenu(fileName = "KGBConnections", menuName = "Items/Legendary/KGBConnections")]
public class KGBConnections : Item
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
        this.rarity = 2;
        this.boss = false;
        this.itemId = "KGBConnections";
        this.itemName="KGBConnections";
        this.toolTipDesc = $"All {StylisticClass.HighLight}face cards{StylisticClass.HighLightClose} gain "+StylisticClass.CrippleColor+StylisticClass.CrippleString+CardInfo.modifierToDescription["Cripple"]+"</color>";
    }

    public override bool OnActivate()
    {
          return false;
    }

    public override bool OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c.IsFace()) 
            {
                c.AddModifier("Cripple");
            }
        }
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        if (card.IsFace()) 
        {
            card.AddModifier("Cripple");
        }
        return true;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
    {
         return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod="")
    {
         return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
         return false;
    }

    public override bool OnEncounterStart()
    {
         return false;
    }

    public override bool OnEndEncounter()
    {
         return false;
    }

    public override bool OnHeal(int amount)
    {
         return false;
    }

    public override bool OnLoad()
    {
           return false;
    }

    public override bool OnPlayedCard(Card card)
    {
         return false;
    }

    public override bool OnReverse(Card card)
    {
          return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
         return false;
    }
}
