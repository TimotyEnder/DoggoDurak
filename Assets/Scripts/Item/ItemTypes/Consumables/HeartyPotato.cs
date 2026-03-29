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

    public override void OnActivate()
    {
        for(int i = 0; i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo c= GameHandler.Instance.GetCardInHand(i);
            c._number++;
            c._card.MakeCard(c);
            c._card.Bling();
            cardsUpgraded.Add(c);
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
        foreach(CardInfo c in cardsUpgraded)
        {
            c._number--;
            if(c._card!=null)
            {
                c._card.MakeCard(c);
                c._card.Bling();
            }
        }
    }
}