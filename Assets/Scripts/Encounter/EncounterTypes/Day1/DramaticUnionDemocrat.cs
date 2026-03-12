using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DramaticUnionDemocrat", menuName = "Encounters/Day1/DramaticUnionDemocrat")]
public class DramaticUnionDemocrat : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'H';
        icon = null;
        encounterName = "Dramatic Union Democrat";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,false,false);
        this.description="Hates Reds!";
        hasRules=true;
        
    }
    public override void AddRules()
    {
       AddRule($"Each time you play a {StylisticClass.HighLight}{CardInfo.suitToColorToolText["D"]}red card</color>{StylisticClass.HighLightClose}you receive"+StylisticClass.DamageNumber(4)); //0
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
        
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsRed())
        {
            GameHandler.Instance.DamagePlayer(4,true);
            ShakeRule(0);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsRed())
        {
            GameHandler.Instance.DamagePlayer(4,true);
            ShakeRule(0);
        }
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }

    public override int AddToDamagePlayer(int amount, string fromMod = "")
    {
        return amount;
    }

    public override int AddToDamageOpponent(int amount, string fromMod = "")
    {
        return amount;
    }
}