using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FurtiveFSBInformant", menuName = "Encounters/Day1/FurtiveFSBInformant")]
public class FurtiveFSBInformant : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Furtive FSB Informant";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true);
        AddRandomModifierToDeck(5,"Parry");
        this.description="A Furtive FSB Informant.";
        hasRules=true;
        AddRule("Each time you play a "+StylisticClass.HighLight+"face card"+StylisticClass.HighLightClose+"you receive"+StylisticClass.DamageNumber(4)); //0
    }

    public override void OnCardDiscarded(CardInfo card)
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
        
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsFace())
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
}