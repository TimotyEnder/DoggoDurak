using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Balalaechnik", menuName = "Encounters/Boss-Day3/Balalaechnik")]
public class Balalaechnik : Encounter
{
    private int _damageInstance;
    public override void InitEncounter()
    {
        day=2;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Balalaechnik";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        _damageInstance=0;
        this.description="His balalaika is deadly!";
        hasRules=true;
    }
    public override void AddRules()
    {
        AddRule($"Every third instance of damage the opponent deals is tripled {compile123text()}");//0
    }
     private string compile123text()
    {
        switch(_damageInstance)
        {
            case 0:
                return "<b>1</b>/2/3";
            case 1:
                return "1/<b>2</b>/3";
            case 2:
                return "1/2/<b><color=red>3</b></color>";
        }
        return "";
    }
    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        int inst=_damageInstance++;
        if(inst==3)
        {
            _damageInstance=0;
            GameHandler.Instance.DamagePlayer(amount,true,times:2);
        }
        UpdateRules();
        ShakeRule(0);
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }

    public override void OnPlayedCard(Card card)
    {
        
    }

    public override void OnPlayedCardDiscarded(CardInfo card)
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
}