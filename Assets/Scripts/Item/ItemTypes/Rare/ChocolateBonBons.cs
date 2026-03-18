using System;
using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "EmergencyContact", menuName = "Items/Active-Rare/ChocolateBonBon")]
class ChocolateBonBon : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "ChocolateBonBon";
        this.itemName="ChocolateBonBon";
        this.toolTipDesc = $"{StylisticClass.ActivateString} The opponent gains {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> counters for each card with {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> in your deck. You discard cards equal to the amount of cards with {StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> in your deck.";
    }

    public override void OnActivate()
    {
        int poisonAmount = GameHandler.Instance.GetGameState()._deck.FindAll(card => card._modifierStacks.ContainsKey("Poison") && card._modifierStacks["Poison"] > 0).Count;
        GameHandler.Instance.PoisonOpponent(poisonAmount);
        GameHandler.Instance.PlayerDiscard(0,Math.Min(poisonAmount,GameHandler.Instance.GetPlayerCardsInHand()));

    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEncounterStart()
    {
        
    }

    public override void OnEndEncounter()
    {
        
    }

    public override void OnHeal(int amount)
    {
        
    }

    public override void OnLoad()
    {
        
    }

    public override void OnPlayedCard(Card card)
    {
        
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        
    }
}