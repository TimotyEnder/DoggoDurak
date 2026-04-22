using System;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "EmergencyContact", menuName = "Items/Active-Rare/ChocolateBonBon")]
class ChocolateBonBon : Item
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
        this.itemId = "ChocolateBonBon";
        this.itemName = "ChocolateBonBon";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} The opponent gains {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> counters for each card with {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> in your deck. You discard cards equal to the amount of cards with {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> in your deck.";
        AddSubtoolTip(ToolTip.SubtoolTips["Poison"]);
    }

    public override bool OnActivate()
    {
        int poisonAmount = GameHandler
            .Instance.GetGameState()
            ._deck.FindAll(card =>
                card._modifierStacks.ContainsKey("Poison") && card._modifierStacks["Poison"] > 0
            )
            .Count;
        GameHandler.Instance.PoisonOpponent(poisonAmount);
        GameHandler.Instance.PlayerDiscard(
            0,
            Math.Min(poisonAmount, GameHandler.Instance.GetPlayerCardsInHand())
        );
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
        throw new NotImplementedException();
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
