using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "BurrowerOfTheBone", menuName = "Items/Active-Rare/BurrowerOfTheBone")]
class BurrowerOfTheBone : Item
{
    public override int AddToDamageOpponent(int amount)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "BurrowerOfTheBone";
        this.itemName="BurrowerOfTheBone";
        this.toolTipDesc = $"{StylisticClass.ActivateString} {StylisticClass.HighLight}Discard{StylisticClass.HighLightClose} your hand and {StylisticClass.HighLight}draw{StylisticClass.HighLightClose} a new hand.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.PlayerDiscard(0,GameHandler.Instance.GetPlayerCardsInHand());
        GameHandler.Instance.Draw(GameHandler.Instance.GetGameState()._handSize);
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