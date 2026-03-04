using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "DictatingDutyOfficer", menuName = "Encounters/Boss-Day2/DictatingDutyOfficer")]
public class DictatingDutyOfficer : Encounter
{
    private int _cardsPlayed;
    private int _cardsToPlay;
    private int _damageToDo;
    public override void InitEncounter()
    {
        day=1;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "DictatingDutyOfficer";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        _cardsPlayed=0;
        _cardsToPlay=SelectCardsToPlay();
        _damageToDo=10;
        this.description="Only a strong combine force of attacks will blow through his shield!";
        hasRules=true;
    }
    private int SelectCardsToPlay()
    {
        return UnityEngine.Random.Range(1,GameHandler.Instance.GetGameState()._handSize/2);
    }
    public override void AddRules()
    {
       AddRule($"Cards played: {compileCardsPlayedText()}");//0
       AddRule($"For each card overplayed the opponent deals {StylisticClass.DamageNumber(_damageToDo)} to you");//1
       AddRule($"At the end of the turn if you have played less cards than dictated, the opponent deals {StylisticClass.DamageNumber(_damageToDo)} to you");//2
       AddRule($"For each turn where you fail to play the correct amount of cards, the damage done increases by 1");//3
    }
    private string compileCardsPlayedText()
    {
        string toRet="";
        if(_cardsPlayed<_cardsToPlay)
        {
            toRet+=$"{StylisticClass.HighLight}{_cardsPlayed}/{_cardsToPlay}{StylisticClass.HighLightClose}";
        }
        else if(_cardsPlayed==_cardsToPlay)
        {
            toRet+=$"<color=green>{StylisticClass.HighLight}{_cardsPlayed}/{_cardsToPlay}{StylisticClass.HighLightClose}</color>";
        }
        else
        {
            toRet+=$"<color=red>{StylisticClass.HighLight}{_cardsPlayed}/{_cardsToPlay}{StylisticClass.HighLightClose}</color>";
        }
        return toRet;
    }
    private void HandleCardPlayed(Card card)
    {
        if(!card.GetCardInfo()._opponentCard)
        {
            _cardsPlayed++;
            UpdateRules();
            if(_cardsPlayed>_cardsToPlay)
            {
                GameHandler.Instance.DamagePlayer(_damageToDo,false);
                ShakeRule(1);
            }
            else
            {
                ShakeRule(0);
            }
        }
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

    public override void OnDefendCard(Card card, Card defended)
    {
        HandleCardPlayed(card);
    }

    public override void OnPlayedCard(Card card)
    {
       HandleCardPlayed(card);
    }

    public override void OnReverse(Card card)
    {
    }

    public override void OnTurnEnd(int turnState)
    {
        if (_cardsPlayed < _cardsToPlay)
        {
            GameHandler.Instance.DamagePlayer(_damageToDo);
            _damageToDo+=1;
            _cardsPlayed=0;
            _cardsToPlay=SelectCardsToPlay();
            UpdateRules();
            ShakeRule(2);
        }
        else
        {
            _cardsPlayed=0;
            _cardsToPlay=SelectCardsToPlay();
            UpdateRules();
            ShakeRule(2);
        }
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}