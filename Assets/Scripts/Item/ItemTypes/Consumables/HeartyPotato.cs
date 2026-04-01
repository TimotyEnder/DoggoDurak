using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HeartyPotato", menuName = "Items/Consumable/HeartyPotato")]
class HeartyPotato : Item
{
    List<CardInfo> cardsUpgraded;

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
        rarity = 0;
        boss = false;
        isActive=true;
        persistent=true;
        consumable=true;
        itemId = "HeartyPotato";
        this.itemName="HeartyPotato";
        this.toolTipDesc = $"{StylisticClass.ConsumeString} Until the end of turn all card in your hand gain +1";
        cardsUpgraded= new List<CardInfo>();
    }

    public override bool OnActivate()
    {
        for(int i = 0; i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo c= GameHandler.Instance.GetCardInHand(i);
            c._number++;
            c._card.MakeCard(c);
            c._card.Bling();
            cardsUpgraded.Add(c);
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
        foreach(CardInfo c in cardsUpgraded)
        {
            c._number--;
            if(c._card!=null)
            {
                c._card.MakeCard(c);
                c._card.Bling();
            }
        }
        return true;
    }
}