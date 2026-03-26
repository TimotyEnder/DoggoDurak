using UnityEngine;
[CreateAssetMenu(fileName = "AlyonkaBar", menuName = "Items/Rare/AlyonkaBar")]
class AlyonkaBar : Item
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "AlyonkaBar";
        this.itemName="AlyonkaBar";
        this.toolTipDesc = $"{StylisticClass.HighLight}Face cards gain {StylisticClass.PoisonColor}{StylisticClass.PoisonString}{CardInfo.modifierToDescription["Poison"]}</color>";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if(c.IsFace())
            {
                c.AddModifier("Poison");
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
         if(card.IsFace())
        {
            card.AddModifier("Poison");
        }
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
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