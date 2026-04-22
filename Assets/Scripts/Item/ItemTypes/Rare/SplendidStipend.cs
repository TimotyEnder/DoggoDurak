using UnityEngine;

[CreateAssetMenu(fileName = "SpelendidStipend", menuName = "Items/Rare/SpelendidStipend")]
class SplendidStipend : Item
{
    private int _leftTillTrigger;

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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "SpelendidStipend";
        this.itemName = "Spelendid Stipend";
        _leftTillTrigger = 0;
        this.toolTipDesc =
            $"Every {StylisticClass.HighLight}10 cards{StylisticClass.HighLightClose} you play, {StylisticClass.HighLight}draw 2{StylisticClass.HighLightClose} cards. ";
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
        if (!defendee.GetCardInfo()._opponentCard)
        {
            _leftTillTrigger++;
        }
        if (_leftTillTrigger >= 10)
        {
            GameHandler.Instance.Draw(2);
            _leftTillTrigger = 0;
            return true;
        }
        return false;
    }

    public override bool OnDrawCard(CardInfo card)
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
        if (!card.GetCardInfo()._opponentCard)
        {
            _leftTillTrigger++;
        }
        if (_leftTillTrigger >= 10)
        {
            GameHandler.Instance.Draw(2);
            _leftTillTrigger = 0;
            return true;
        }
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
