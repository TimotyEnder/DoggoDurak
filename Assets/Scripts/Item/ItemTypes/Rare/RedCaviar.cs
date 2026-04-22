using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RedCaviar", menuName = "Items/Rare/RedCaviar")]
public class RedCaviar : Item
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
        this.itemId = "RedCaviar";
        this.itemName = "RedCaviar";
        this.toolTipDesc =
            $"20 random {StylisticClass.HighLight}red cards{StylisticClass.HighLightClose} gain {StylisticClass.HighLight}+1{StylisticClass.HighLightClose} ";
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        List<CardInfo> redCards = new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c._suit == "D" || c._suit == "H")
            {
                redCards.Add(c);
            }
        }
        UpgradeRandomCards(20, 1, redCards);
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
