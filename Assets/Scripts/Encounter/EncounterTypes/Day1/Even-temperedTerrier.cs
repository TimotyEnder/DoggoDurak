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
        trumpSuit = 'H';
        icon = null;
        encounterName = "Even-tempered Terrier";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,false,false,true,true);
        this.description="Hates odd looking chaps!";
        hasRules=true;
        AddRule("Each time you play an "+StylisticClass.HighLight+"even numbered card"+StylisticClass.HighLightClose+"you receive"+StylisticClass.DamageNumber(2)); //0
    }

    public override void OnDamagePlayer(int amount)
    {
        
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsOdd())
        {
            GameHandler.Instance.DamagePlayer(4,true);
            ShakeRule(0);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsOdd())
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
}