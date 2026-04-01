using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "OligarchsPrerogative", menuName = "Items/Active-Legendary/OligarchsPrerogative")]
class OligarchsPrerogative : Item
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
        this.itemId = "OligarchsPrerogative";
        this.itemName="Oligarch's Prerogative";
        this.toolTipDesc = $"{StylisticClass.ActivateString} {StylisticClass.HighLight}All{StylisticClass.HighLightClose} cards in your hand lose {StylisticClass.Debuffed} until the end of the turn";
    }

    public override bool OnActivate()
    {
        for(int i=0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo card= GameHandler.Instance.GetCardInHand(i);
            GameHandler.Instance.SetDebuffs(new string[]{$"{card._suit}{card._number}"},false,GameHandler.Instance.IsCardnotDebuffed(card,1));
            card._card.CheckDebuffVisual();
            card._card.Bling();
        }
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