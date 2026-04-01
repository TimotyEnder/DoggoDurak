using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "OligarchsPrestige", menuName = "Items/Active-Legendary/OligarchsPrestige")]
class OligarchsPrestige : Item
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
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.itemId = "OligarchsPrestige";
        this.itemName="Oligarch's Prestige";
        this.toolTipDesc = $"{StylisticClass.ActivateString} Opponent {StylisticClass.HighLight}discards 1 card{StylisticClass.HighLightClose} for each card in your hand with at {StylisticClass.HighLight}least 1 modifier{StylisticClass.HighLightClose}";
    }

    public override bool OnActivate()
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

    public override bool OnDamagePlayer(int amount, string fromMod="")
    {
         return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
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