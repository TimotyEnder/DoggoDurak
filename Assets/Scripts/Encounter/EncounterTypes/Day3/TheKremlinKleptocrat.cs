using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using Febucci.Attributes;
[CreateAssetMenu(fileName = "TheKremlinKleptocrat", menuName = "Encounters/Day3/TheKremlinKleptocrat")]
public class TheKremlinKleptocrat : Encounter
{
    private List<string> _cardsDiscardedByPlayer;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Kremlin Kleptocrat";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        _cardsDiscardedByPlayer= new List<string>();
        this.description="Apparently the real treasure isn't in the state coffers, it's in everyone else's pockets.";
        hasRules=true;
    }
    private void CopyCard(CardInfo card)
    {
        if(!card._opponentCard)
        {
            string toAdd= card._suit+card._number;
            _cardsDiscardedByPlayer.Add(toAdd);
            CardInfo min= this.deck[0];
            foreach(CardInfo c in this.deck) //remove a card at random.
            {
                if(min._number>c._number)
                {
                    min=c;
                }
            }
            this.deck.Remove(min);
            AddToDeck(card); 
            ShakeRule(0);
        }
    }
    public override void AddRules()
    {
       AddRule("Card discarded by the player are copied into the opponent's deck. Cards with the same number and suit that you own are debuffed "); //0
       AddRule("At the end of the turn, the opponent copies 10 random cards from your deck. They are also "+StylisticClass.Debuffed+" for you."); //1
    }
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
        CopyCard(card);
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
        int cardsTransferred=0;
        foreach(CardInfo playerCard in GameHandler.Instance.GetGameState()._deck)
        {
            int roll = Random.Range(0,10);
            if(roll<1)
            {

                cardsTransferred++;
                CopyCard(playerCard);
            }
        }
        GameHandler.Instance.EnemyStealingCardParticles(cardsTransferred);
        ShakeRule(1);
    }

    public override void SetDebuffs()
    {
        string [] perms = _cardsDiscardedByPlayer.ToArray();
        GameHandler.Instance.SetDebuffs(perms,true,false);
        ShakeRule(0);
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        CopyCard(card);
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }
}