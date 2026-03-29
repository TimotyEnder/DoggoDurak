using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DachaDoorstep", menuName = "Items/Common/DachaDoorstep")]
public class DachaDoorstep : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "DachaDoorstep";
        this.itemName="DachaDoorstep";
        this.toolTipDesc = "5 random cards gain "+StylisticClass.BounceColor+StylisticClass.BounceString+CardInfo.modifierToDescription["Bounce"]+"</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        AddModToRandomCards(5,"Bounce");
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
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
