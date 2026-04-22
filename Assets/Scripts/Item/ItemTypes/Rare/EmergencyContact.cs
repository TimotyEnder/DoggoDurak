using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "EmergencyContact", menuName = "Items/Active-Rare/EmergencyContact")]
public class EmergencyContact : Item
{
    public EmergencyContact()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive = true;
        this.itemId = "EmergencyContact";
        this.itemName = "EmergencyContact";
        this.toolTipDesc =
            StylisticClass.ActivateString + " Discard right-most card, draw 1 card and heal 5 hp.";
    }

    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override void InitItem() { }

    public override bool OnActivate()
    {
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetPlayerCardsInHand() - 1);
        GameHandler.Instance.Draw(1);
        GameHandler.Instance.HealPlayer(5);
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
