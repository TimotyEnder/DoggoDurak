using UnityEngine;
[CreateAssetMenu(fileName = "PrimeLaikaDirective", menuName = "Items/Rare/PrimeLaikaDirective")]
class PrimeLaikaDirective : Item
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
        this.itemId = "PrimeLaikaDirective";
        this.itemName="PrimeLaikaDirective";
        this.toolTipDesc = $"All {StylisticClass.HighLight}7s and Jacks{StylisticClass.HighLightClose} become {StylisticClass.Laika} and gain {StylisticClass.BurnColor}{StylisticClass.BurnString} 5 {CardInfo.modifierToDescription["Burn"]} </color>";
    }

    public override bool OnActivate()
    {
         return false;
    }

    public override bool OnAquire()
    {
        foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if(c.IsLaika())
            {
                c.AddModifier("Burn",5);
                c.AddModifier("Bounce");
            }
        }
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        if(card.IsLaika())
        {
            card.AddModifier("Burn",5);
            card.AddModifier("Bounce");
        }
        return true;
    }

    public override bool OnDamageOpponent(int amount, string fromMod = "")
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