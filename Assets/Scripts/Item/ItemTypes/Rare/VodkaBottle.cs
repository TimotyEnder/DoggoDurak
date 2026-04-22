using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "VodkaBottle", menuName = "Items/Active-Rare/VodkaBottle")]
class VodkaBottle : Item
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
        this.isActive = true;
        this.itemId = "VodkaBottle";
        this.itemName = "Vodka Bottle";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} This turn all the cards in your hand are {StylisticClass.DebuffedDesc}. You heal {StylisticClass.HighLight}20 hp{StylisticClass.HighLightClose}.";
    }

    public override bool OnActivate()
    {
        List<string> toDebuff = new List<string>();
        for (int i = 0; i < GameHandler.Instance.GetPlayerCardsInHand(); i++)
        {
            CardInfo card = GameHandler.Instance.GetCardInHand(i);
            card._card.SetDebuffed(true);
        }
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
        return false;
    }
}
