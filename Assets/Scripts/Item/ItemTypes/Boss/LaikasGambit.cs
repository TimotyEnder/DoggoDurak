using UnityEngine;

[CreateAssetMenu(fileName = "LaikasGambit", menuName = "Items/Boss/LaikasGambit")]
class LaikasGambit : Item
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
        this.rarity = 3;
        this.boss = true;
        this.itemId = "LaikasGambit";
        this.itemName = "Laika's Gambit";
        this.toolTipDesc =
            $"All {StylisticClass.HighLight} you face cards{StylisticClass.HighLightClose} are now {StylisticClass.HighLight}Laika Cards{StylisticClass.HighLightClose}";
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
            if (c.IsFace())
            {
                c.MakeLaika();
            }
        }
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        if (card.IsFace())
        {
            card.MakeLaika();
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
