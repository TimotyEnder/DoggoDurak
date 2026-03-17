using UnityEngine;
[CreateAssetMenu(fileName = "UZB76", menuName = "Items/Legendary/UZB76")]
class UZB76 : Item
{
    private bool _copied;
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "UZB76";
        this.itemName="UZB-76 Signal Repeater";
        this.toolTipDesc = $"{StylisticClass.HighLight}Copy{StylisticClass.HighLightClose} the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} card played every {StylisticClass.HighLight}encounter{StylisticClass.HighLightClose}.";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
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
        _copied=false;
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
        if(!_copied && !card.GetCardInfo()._opponentCard)
        {
            _copied = false;
            CardInfo cardCopy= new CardInfo(card.GetCardInfo());
            GameHandler.Instance.AddCardToDeck(cardCopy);
        }
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        
    }
}