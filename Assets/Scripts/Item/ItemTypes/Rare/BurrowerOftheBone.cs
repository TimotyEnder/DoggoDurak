using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "BurrowerOfTheBone", menuName = "Items/Active-Rare/BurrowerOfTheBone")]
class BurrowerOfTheBone : Item
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
        this.itemId = "BurrowerOfTheBone";
        this.itemName = "BurrowerOfTheBone";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} {StylisticClass.HighLight}Discard{StylisticClass.HighLightClose} your hand and {StylisticClass.HighLight}draw{StylisticClass.HighLightClose} a new hand.";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.PlayerDiscard(0, GameHandler.Instance.GetPlayerCardsInHand());
        GameHandler.Instance.Draw(GameHandler.Instance.GetGameState()._handSize);
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
