using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "TheBurningIronCurtain", menuName = "Encounters/Boss-Day3/TheBurningIronCurtain")]
public class TheBurningIronCurtain : Encounter
{
    public override void AddRules()
    {
        AddRule($"{StylisticClass.HighLight}ALL{StylisticClass.HighLightClose} suits are {StylisticClass.Debuffed}");//0
    }

    public override void InitEncounter()
    {
        day=2;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "TheBurningIronCurtain";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        customInitDeck();
        this.description="Crumbling, burning but refusing to give up...";
        hasRules=true;
    }
    private void customInitDeck()
    {
         this.deck= new List<CardInfo>();
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:

                        for (int j = 8; j < 10; j++)
                        {
                               deck.Add(new CardInfo("C", j, true));
                        }
                    
                    break;
                case 1:

                        for (int j = 8; j < 10; j++)
                        {
                                deck.Add(new CardInfo("S", j, true));
                        }
                    
                    break;
                case 2:

                        for (int j = 8; j < 10; j++)
                        {

                                deck.Add(new CardInfo("D", j, true));
                            
                        }
                    
                    break;
                case 3:

                        for (int j = 8; j < 10; j++)
                        {
                                deck.Add(new CardInfo("H", j, true));
                        }
                    
                    break;
            }
        }
        foreach(CardInfo c in this.deck)
        {
            for(int i=0;i<8;i++)
            {
                c.AddModifier("Burn");
            }
        }
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        
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
        GameHandler.Instance.SetDebuffs(new string[]{"C","D","H","S"},true,true);
    }
}