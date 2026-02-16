using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "EmergencyContact", menuName = "Items/Active-Rare/EmergencyContact")]
public class EmergencyContact : Item
{
    public EmergencyContact()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "EmergencyContact";
        this.toolTipDesc = StylisticClass.ActivateString+" Discard right-most card, draw 1 card and heal 5 hp.";
    }

    public override void InitItem()
    {
        
    }

    public override void OnActivate()
    {
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetCardsInHand()-1);
        GameHandler.Instance.Draw(1);
        GameHandler.Instance.HealPlayer(5);
    }

    public override void OnAquire()
    {

    }

    public override void OnDamageOpponent(int amount)
    {

    }

    public override void OnDefendCard(Card defendee, Card defended)
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
}