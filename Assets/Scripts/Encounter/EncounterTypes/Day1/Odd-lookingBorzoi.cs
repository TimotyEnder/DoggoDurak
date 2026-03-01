using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "OddlookingBorzoi", menuName = "Encounters/Day1/OddlookingBorzoi")]
public class OddlookingBorzoi : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Odd-looking Borzoi";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true,false,true);
        this.description="Hates the even-tempered!";
        hasRules=true;
        AddRule("Each time you play an "+StylisticClass.HighLight+"even numbered card"+StylisticClass.HighLightClose+"you receive"+StylisticClass.DamageNumber(2)); //0
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
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsEven())
        {
            GameHandler.Instance.DamagePlayer(2,true);
            ShakeRule(0);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsEven())
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

    public override void SetPlayPermissions()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}