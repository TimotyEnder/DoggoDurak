using UnityEngine;

[CreateAssetMenu(
    fileName = "ContrabandCarePackage",
    menuName = "Items/Common/ContrabandCarePackage"
)]
public class ContrabandCarePackage : Item
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
        this.rarity = 0;
        this.boss = false;
        this.itemId = "ContrabandCarePackage";
        this.itemName = "ContrabandCarePackage";
        this.toolTipDesc =
            "5 random cards gain "
            + StylisticClass.DrawColor
            + StylisticClass.DrawString
            + " 1</color>";
        AddSubtoolTip(ToolTip.SubtoolTips["Draw"]);
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        AddModToRandomCards(5, "Draw");
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
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
