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
        initDeck(10,false,false,true,true);
        this.description="Hates Reds!";
        hasRules=true;
        AddRule("Each time you play a "+StylisticClass.HighLight+"red card"+StylisticClass.HighLightClose+"you receive"+StylisticClass.DamageNumber(4)); //0
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

    public override void SetPlayPermissions()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}