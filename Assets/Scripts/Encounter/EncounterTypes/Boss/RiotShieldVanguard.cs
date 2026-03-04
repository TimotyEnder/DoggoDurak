using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "RiotShieldVanguard", menuName = "Encounters/Boss-Day2/RiotShieldVanguard")]
public class RiotShieldVanguard : Encounter
{
    private bool _blownThrough;
    private int _damageToBlownThrough;
    private int _damageDone;
    private int _damageReduction;
    public override void InitEncounter()
    {
        day=1;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Riot Shield Vanguard";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        _blownThrough=false;
        _damageToBlownThrough=10;
        _damageReduction=6;
        _damageDone=0;
        this.description="Only a strong combine force of attacks will blow through his shield!";
        GameHandler.Instance.GetGameState()._opponentsDamageReduction=_damageReduction;
        hasRules=true;
    }
    public override void AddRules()
    {
        if(_blownThrough)
        {
            AddRule("The opponent recieves triple damage from all sources.");//0
        }
        else
        {
            AddRule("Any damage done to the opponent is decreased by 6. ");//0
        }
        AddRule($"If the opponent is dealt {StylisticClass.DamageNumber(_damageToBlownThrough)} in one turn {StylisticClass.HighLight}({_damageDone}/{_damageToBlownThrough}){StylisticClass.HighLightClose}, damage from all sources is tripled.");//1
    }

    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
       if(!_blownThrough)
       {
            _damageDone+=amount>0?amount:0;
            if(_damageDone>_damageToBlownThrough)
            {
                _blownThrough=true;
                UpdateRules();
                GameHandler.Instance.GetGameState()._opponentsDamageReduction=0;
                GameHandler.Instance.DamageOpponent(amount,true,times:2);
                ShakeRule(0);
            }
            else
            {
                UpdateRules();
                ShakeRule(1);
            }
        }
        else
        {
            GameHandler.Instance.DamageOpponent(amount,true,times:2);
        }
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
       if(_blownThrough){ _damageToBlownThrough--;}
       _blownThrough=false;
        GameHandler.Instance.GetGameState()._opponentsDamageReduction=_damageDone;
       _damageDone=0;
       UpdateRules();
       ShakeRule(0);
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}