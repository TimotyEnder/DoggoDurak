using UnityEngine;

[CreateAssetMenu(fileName = "LaikasFavor", menuName = "Items/Legendary/LaikasFavor")]
class LaikasFavor : Item
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
        this.rarity = 2;
        this.boss = false;
        this.itemId = "LaikasFavor";
        this.itemName = "Laika's Favor";
        this.toolTipDesc =
            $"{StylisticClass.HighLight}Laika Cards{StylisticClass.HighLightClose} have number {StylisticClass.HighLight}1{StylisticClass.HighLightClose}";
        AddSubtoolTip(ToolTip.SubtoolTips["Laika"]);
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c.IsLaika())
            {
                c._number = 1;
            }
        }
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        if (card.IsLaika())
        {
            card._number = 1;
        }
        return true;
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
