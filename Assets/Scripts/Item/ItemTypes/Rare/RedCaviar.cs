using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RedCaviar", menuName = "Items/Rare/RedCaviar")]
public class RedCaviar : Item
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "RedCaviar";
        this.itemName="RedCaviar";
        this.toolTipDesc = $"20 random {StylisticClass.HighLight}red cards{StylisticClass.HighLightClose} gain {StylisticClass.HighLight}+1{StylisticClass.HighLightClose} ";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        List<CardInfo> redCards= new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c._suit=="D"|| c._suit == "H")
            {
               redCards.Add(c);
            }
        }
        UpgradeRandomCards(20,1,redCards);
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
