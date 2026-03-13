using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "OligarchsPrestige", menuName = "Items/Active-Legendary/OligarchsPrestige")]
class OligarchsPrestige : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.itemId = "OligarchsPrestige";
        this.itemName="Oligarch's Prestige";
        this.toolTipDesc = $"{StylisticClass.ActivateString} Opponent {StylisticClass.HighLight}discards 1 card{StylisticClass.HighLightClose} for each card in your hand with at {StylisticClass.HighLight}least 1 modifier{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        int cardsToDiscard=0;
        for(int i=0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo card= GameHandler.Instance.GetCardInHand(i);
            if (card._modifierStacks.Count > 0)
            {
                cardsToDiscard++;
            }
        }
        GameHandler.Instance.OpponentDiscard(cardsToDiscard);
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