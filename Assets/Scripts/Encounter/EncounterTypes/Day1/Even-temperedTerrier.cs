using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EventemperedTerrier", menuName = "Encounters/Day1/EventemperedTerrier")]
public class EventemperedTerrier : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Even-tempered Terrier";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true,true,false);
        this.description="Hates odd looking chaps!";
        hasRules=true;
       
    }
    public override void AddRules()
    {
       AddRule("Each time you play an "+StylisticClass.HighLight+"odd numbered card "+StylisticClass.HighLightClose+"you receive "+StylisticClass.DamageNumber(2)); //0
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
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsOdd())
        {
            GameHandler.Instance.DamagePlayer(2,true);
            ShakeRule(0);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsOdd())
        {
            GameHandler.Instance.DamagePlayer(2,true);
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
}