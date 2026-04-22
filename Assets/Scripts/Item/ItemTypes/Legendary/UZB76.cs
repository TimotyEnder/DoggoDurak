using UnityEngine;

[CreateAssetMenu(fileName = "UZB76", menuName = "Items/Legendary/UZB76")]
class UZB76 : Item
{
    private bool _copied;

    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "UZB76";
        this.itemName = "UZB-76 Signal Repeater";
        this.toolTipDesc =
            $"{StylisticClass.HighLight}Copy{StylisticClass.HighLightClose} the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} card played every {StylisticClass.HighLight}encounter{StylisticClass.HighLightClose}.";
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod = "")
    {
        return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod = "")
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnDrawCard(CardInfo card)
    {
        return false;
    }

    public override bool OnEncounterStart()
    {
        _copied = false;
        return true;
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
        if (!_copied && !card.GetCardInfo()._opponentCard)
        {
            _copied = false;
            CardInfo cardCopy = new CardInfo(card.GetCardInfo());
            GameHandler.Instance.AddCardToDeck(cardCopy);
        }
        return true;
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
