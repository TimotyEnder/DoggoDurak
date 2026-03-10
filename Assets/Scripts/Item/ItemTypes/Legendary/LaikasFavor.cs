using UnityEngine;
[CreateAssetMenu(fileName = "LaikasFavor", menuName = "Items/Legendary/LaikasFavor")]
class LaikasFavor : Item
{
    public override void InitItem()
    {
         this.rarity = 2;
        this.boss = false;
        this.itemId = "Laika's Favor";
        this.toolTipDesc = $"{StylisticClass.HighLight}Laika Cards{StylisticClass.HighLightClose} have number {StylisticClass.HighLight}1{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if(c.IsLaika())
            {
                c._number=1;
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
        if(card.IsLaika())
        {
            card._number=1;
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