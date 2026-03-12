using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RussianRouletteRascal", menuName = "Encounters/Day2/RussianRouletteRascal")]
public class RussianRouletteRascal : Encounter
{
    private int crestProbability=50;
    private int _opponentDamageTaken=0;
    private int _playerDamageTaken=0;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Russian Roulette Rascal";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        this.description="Why is there revolver on the table?!";
        hasRules=true;
        
    }
    public override void AddRules()
    {
       AddRule("After each turn flip a coin,  Crest "+StylisticClass.HighLight+"("+crestProbability+"%)"+StylisticClass.HighLightClose+": opponent takes "+StylisticClass.DamageNumber(35)+",  Grate "+StylisticClass.HighLight+"("+(100-crestProbability)+"%)"+StylisticClass.HighLightClose+": you take "+StylisticClass.DamageNumber(35)+". For each "+StylisticClass.DamageNumber(5)+" you take Grate probability "+StylisticClass.HighLight+"+1%"+StylisticClass.HighLightClose+". For each "+StylisticClass.DamageNumber(5)+" the opponent takes Crest probability "+StylisticClass.HighLight+"+1%"+StylisticClass.HighLightClose+"."); //0
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
       if(fromMod!="RussianRouletteRascal")
       {
           _opponentDamageTaken+=amount;
           int percentageIncrease= _opponentDamageTaken/5;
           _opponentDamageTaken=_opponentDamageTaken%5;
           crestProbability+=percentageIncrease;
           if(crestProbability>100)
           {
               crestProbability=100;
           }
           UpdateRules();
           ShakeRule(0);
       }
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
        if(fromMod!="RussianRouletteRascal")
        {
            _playerDamageTaken+=amount;
            int percentageIncrease= _playerDamageTaken/5;
            _playerDamageTaken=_playerDamageTaken%5;
            crestProbability-=percentageIncrease;
            if(crestProbability<0)
            {
                crestProbability=0;
            }
            UpdateRules();
            ShakeRule(0);
        }
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
        int roll = Random.Range(0, 100);
        if(roll<crestProbability)
        {
            GameHandler.Instance.DamageOpponent(35,fromMod:"RussianRouletteRascal");
        }
        else
        {
            GameHandler.Instance.DamagePlayer(35,fromMod:"RussianRouletteRascal");
        }
        ShakeRule(0);
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