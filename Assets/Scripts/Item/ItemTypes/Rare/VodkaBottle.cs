using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "VodkaBottle", menuName = "Items/Active-Rare/VodkaBottle")]
class VodkaBottle : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "VodkaBottle";
        this.itemName="Vodka Bottle";
        this.toolTipDesc = $"{StylisticClass.ActivateString} This turn all the cards in your hand are {StylisticClass.Debuffed}. You heal {StylisticClass.HighLight}20 hp{StylisticClass.HighLightClose}.";
    }

    public override void OnActivate()
    {
        for(int i =0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo card= GameHandler.Instance.GetCardInHand(i);
            GameHandler.Instance.SetDebuffs(new string[]{$"{card._suit}{card._number}"},true,GameHandler.Instance.IsCardnotDebuffed(card,1));
        }
        GameHandler.Instance.HealPlayer(20);
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