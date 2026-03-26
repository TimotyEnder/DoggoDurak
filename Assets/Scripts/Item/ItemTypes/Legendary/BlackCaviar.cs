using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BlackCaviar", menuName = "Items/Legendary/BlackCaviar")]
public class BlackCaviar : Item
{
    public override int AddToDamageOpponent(int amount)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "BlackCaviar";
        this.itemName="BlackCaviar";
        this.toolTipDesc = "+2 value to all black cards";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        List<CardInfo> blackCards= new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c._suit=="S"|| c._suit == "C")
            {
               blackCards.Add(c);
            }
        }
        UpgradeRandomCards(20,2,blackCards);
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
