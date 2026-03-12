using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI.Styles;
[CreateAssetMenu(fileName = "TankerTerrier", menuName = "Encounters/Day3/TankerTerrier")]
public class TankerTerrier : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Tanker Terrier";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        AddRandomModifierToDeck(15,"Bounce");
        AddRandomModifierToDeck(60,"Spiky");
        this.description="The armor seems hard. But brittle!";
        hasRules=true;
        GameHandler.Instance.GetGameState()._opponentsDamageReduction=10;
    }
    public override void AddRules()
    {
       AddRule("When the opponent is above"+StylisticClass.HighLight+" 75hp"+StylisticClass.HighLightClose+" they recieve"+StylisticClass.DamageNumber(10)+" less from all sources. Otherwise they recieve triple damage from all sources"); //0
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        if(this.health<75)
        {
            if(GameHandler.Instance.GetGameState()._opponentsDamageReduction>0)
            {
                GameHandler.Instance.GetGameState()._opponentsDamageReduction=0;
            }
            GameHandler.Instance.DamageOpponent(amount*2,true,"TankerTerrier");
        }
        ShakeRule(0);
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
    }

    public override void OnDefendCard(Card card, Card defendedWith)
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