using UnityEngine;

[CreateAssetMenu(fileName = "ChocolateCandy", menuName = "Items/Consumable/ChocolateCandy")]
class ChocolateCandy : Item
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
        itemId = "ChocolateCandy";
        this.itemName = "ChocolateCandy";
        this.toolTipDesc =
            $"{StylisticClass.ConsumeString} Until the end of the turn, all cards in your hand gain {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color>";
        AddSubtoolTip(ToolTip.SubtoolTips["Poison"]);
    }

    public override bool OnActivate()
    {
        for (int i = 0; i < GameHandler.Instance.GetPlayerCardsInHand(); i++)
        {
            CardInfo c = GameHandler.Instance.GetCardInHand(i);
            c.AddModifier("Poison", 5, false);
            c._card.MakeCard(c);
            c._card.Bling();
        }
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
        return false;
    }
}
