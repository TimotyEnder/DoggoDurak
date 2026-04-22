using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlackCaviar", menuName = "Items/Legendary/BlackCaviar")]
public class BlackCaviar : Item
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
        this.itemId = "BlackCaviar";
        this.itemName = "BlackCaviar";
        this.toolTipDesc = "+2 value to all black cards";
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        List<CardInfo> blackCards = new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c._suit == "S" || c._suit == "C")
            {
                blackCards.Add(c);
            }
        }
        UpgradeRandomCards(20, 2, blackCards);
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
