using UnityEngine;

[CreateAssetMenu(fileName = "SelfSharpeningShiv", menuName = "Items/Rare/SelfSharpeningShiv")]
class SelfSharpeningShiv : Item
{
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
        this.itemId = "SelfSharpeningShiv";
        this.itemName = "Self Sharpening Shiv";
        this.toolTipDesc =
            $"Whenever you {StylisticClass.HighLight}reverse{StylisticClass.HighLightClose} with a card, there is a {StylisticClass.HighLight}5%{StylisticClass.HighLightClose} chance it gains {StylisticClass.HighLight}+1{StylisticClass.HighLightClose} permanently.";
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
        int roll = UnityEngine.Random.Range(1, 101);
        if (roll < 5 && !card.GetCardInfo()._opponentCard)
        {
            card.GetCardInfo()._number++;
            card.MakeCard(card.GetCardInfo());
            return true;
        }
        return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
        return false;
    }
}
