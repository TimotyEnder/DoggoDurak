using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System;
[CreateAssetMenu(fileName = "TheGypsyWolfhound", menuName = "Encounters/Boss-Day1/TheGypsyWolfhound")]
public class TheGypsyWolfhound : Encounter
{
    private bool evenTurn=false;
    HashSet<CardInfo> nominatedCards;
    public override void InitEncounter()
    {
        day=0;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Gypsy Wolfhound";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        nominatedCards=new HashSet<CardInfo>();
        this.description="His foresight is only as deep as your pockets.";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule("The the start of the turn, the opponent nominates 3 cards in your hand:\n"+nominateCards()); //0
       AddRule("If you end the turn with any of those cards in your hand, they will deal their damage to you."); //1
    }
    public  string nominateCards()
    {
        if(GameHandler.Instance.GetPlayerCardsInHand()==0)
        {
            return "Next turn...";
        }
        for(int i=0;i<3;i++)
        {
            int index=UnityEngine.Random.Range(0,GameHandler.Instance.GetPlayerCardsInHand());
            while(nominatedCards.Contains(GameHandler.Instance.GetCardInHand(index)))
            {
                index=UnityEngine.Random.Range(0,GameHandler.Instance.GetPlayerCardsInHand());
            }
            nominatedCards.Add(GameHandler.Instance.GetCardInHand(index));
            GameHandler.Instance.GetCardInHand(index)._card.Mark();
        }
        string toRet="";
        foreach(CardInfo card in nominatedCards)
        {
            toRet+=$"{CardInfo.suitToColorToolText[card._suit]}{CardInfo.GetNumberFullName(card._number)} {CardInfo.suitFullName[card._suit]}</color>\n";
        }
        return toRet;
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
        
    }

    public override void OnPlayedCard(Card card)
    {
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        OnTurnEndAsync(turnState).Forget();
    }
    public async UniTask OnTurnEndAsync(int turnState)
    {
        List<CardInfo> cardsToDamage = new List<CardInfo>();
        
        for(int i = 0; i < GameHandler.Instance.GetPlayerCardsInHand(); i++)
        {
            CardInfo cardInHand = GameHandler.Instance.GetCardInHand(i);
            if(nominatedCards.Contains(cardInHand))
            {
                cardsToDamage.Add(cardInHand);
            }
        }
        
        foreach(CardInfo card in cardsToDamage)
        {
            if(card != null && card._card != null) 
            {
                GameHandler.Instance.DamagePlayer(card._number, fromMod: "The Gypsy Wolfhound Rule");
                
                if(card._card != null)
                {
                    card._card.Unmark();
                    card._card.Bling();
                }
                
                ShakeRule(1);
                await UniTask.Delay(100);
            }
        }
        
        // Clear nominations for next turn
        foreach(CardInfo card in nominatedCards)
        {
            if(card != null && card._card != null)
            {
                card._card.Unmark(); 
            }
        }
        nominatedCards.Clear();
        
        UpdateRules();
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
}