using UnityEngine;
[CreateAssetMenu(fileName = "PrimeLaikaDirective", menuName = "Items/Rare/PrimeLaikaDirective")]
class PrimeLaikaDirective : Item
{
    public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.itemId = "PrimeLaikaDirective";
        this.toolTipDesc = $"All {StylisticClass.HighLight}7s and Jacks{StylisticClass.HighLightClose} become {StylisticClass.Laika} and gain {StylisticClass.BurnColor}{StylisticClass.BurnString} 5 {CardInfo.modifierToDescription["Burn"]} </color>";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if(c._number==7 || c._number==11)
            {
                c.MakeLaika();
                c.AddModifier("Burn",5);
            }
        }
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
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