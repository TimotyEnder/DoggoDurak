using UnityEngine;

[CreateAssetMenu(fileName = "BagOfTreats", menuName = "Items/Consumable/BagOfTreats")]
class BagOfTreats : Item
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
        rarity = 0;
        boss = false;
        isActive = true;
        persistent = true;
        consumable = true;
        itemId = "BagOfTreats";
        this.itemName = "BagOfTreats";
        this.toolTipDesc =
            $"Each turn heal {StylisticClass.HighLight}1hp{StylisticClass.HighLightClose}. This amount cannot be increased. {StylisticClass.ConsumeString} gain {StylisticClass.HighLight}20hp{StylisticClass.HighLightClose}";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.HealPlayer(20);
        return true;
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
        return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
        GameHandler.Instance.HealPlayer(1, true);
        return true;
    }
}
