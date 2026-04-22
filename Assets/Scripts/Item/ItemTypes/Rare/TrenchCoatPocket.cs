using UnityEngine;

[CreateAssetMenu(fileName = "TrenchCoatPocket", menuName = "Items/Rare/TrenchCoatPocket")]
class TrenchCoatPocket : Item
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
        this.itemId = "TrenchCoatPocket";
        this.itemName = "Trench Coat Pocket";
        this.toolTipDesc =
            $"Whenever you {StylisticClass.HighLight}draw{StylisticClass.HighLightClose} a card there is a {StylisticClass.HighLight}5%{StylisticClass.HighLightClose} chance to {StylisticClass.HighLight}draw{StylisticClass.HighLightClose} another card.";
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
        int roll = UnityEngine.Random.Range(1, 101);
        if (roll < 5)
        {
            GameHandler.Instance.Draw(1);
            return true;
        }
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
