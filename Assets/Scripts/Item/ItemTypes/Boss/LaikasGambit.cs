using UnityEngine;
[CreateAssetMenu(fileName = "LaikasGambit", menuName = "Items/Boss/LaikasGambit")]
class LaikasGambit : Item
{
    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.itemId = "LaikasGambit";
        this.itemName="Laika's Gambit";
        this.toolTipDesc = $"All {StylisticClass.HighLight} you face cards{StylisticClass.HighLightClose} are now {StylisticClass.Laika}";
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
                c.MakeLaika();
            }
        }
    }

    public override void OnCardAdded(CardInfo card)
    {
        if(card.IsFace())
        {
            card.MakeLaika();
        }
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
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