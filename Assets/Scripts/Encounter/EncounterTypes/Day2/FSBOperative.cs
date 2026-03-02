using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FSBOperative", menuName = "Encounters/Day2/FSBOperative")]
public class FSBOperative : Encounter
{
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "FSB Operative";
        goldRewardMod = 1.5f;
        SetHealth();
        initDeck(12,true,true,true,true);
        foreach(CardInfo card in deck)
        {
            if(card.IsOdd())
            {
                card.AddModifier("Parry");
            }
        }
        this.description="An FSB operative, showing face is unsafe here.";
        hasRules=true;
       
    }
    public override void AddRules()
    {
        AddRule("Your face cards are "+StylisticClass.Debuffed); //0
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
    }

    public override void SetDebuffs()
    {
        GameHandler.Instance.SetDebuffs(new string[]{"C11","C12","C13","H11","H12","H13","S11","S12","S13","D11","D12","D13"},true, false);
        ShakeRule(0);
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}