using System.Diagnostics;

class LaikasNumber : Item
{
    private int _turnsPlayed=0;
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "Laika's Number";
        this.toolTipDesc = $"On the {StylisticClass.HighLight}5th turn{StylisticClass.HighLightClose} of an encounter, {StylisticClass.HighLight}add a Laika Card{StylisticClass.HighLightClose} to your deck";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        
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
        _turnsPlayed++;
        if(_turnsPlayed==5)
        {
            GameHandler.Instance.AddCardToDeck(new CardInfo("L",0));
        }
    }
}