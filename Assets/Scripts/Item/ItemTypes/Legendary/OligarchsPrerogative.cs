using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "OligarchsPrerogative", menuName = "Items/Active-Legendary/OligarchsPrerogative")]
class OligarchsPrerogative : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.itemId = "OligarchsPrerogative";
        this.itemName="Oligarch's Prerogative";
        this.toolTipDesc = $"{StylisticClass.ActivateString} {StylisticClass.HighLight}All{StylisticClass.HighLightClose} cards in your hand lose {StylisticClass.Debuffed} until the end of the turn";
    }

    public override void OnActivate()
    {
        for(int i=0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo card= GameHandler.Instance.GetCardInHand(i);
            GameHandler.Instance.SetDebuffs(new string[]{$"{card._suit}{card._number}"},false,GameHandler.Instance.IsCardnotDebuffed(card,1));
            card._card.CheckDebuffVisual();
            card._card.Bling();
        }
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