
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "TheAdaptiveAlabai", menuName = "Encounters/Day3/TheAdaptiveAlabai")]
public class TheAdaptiveAlabai : Encounter
{
    HashSet<int> numbers;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Adaptive Alabai";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        UpgradeRandomCardsInDeck(15,1);
        numbers= new HashSet<int>();
        this.description="The same trick won't work twice!";
        hasRules=true;
    }
    public override void AddRules()
    {
        AddRule("Cards that have the "+StylisticClass.HighLight+"same number"+StylisticClass.HighLightClose+" as any of the cards you  played this game  are "+StylisticClass.Debuffed+".");//0
        AddRule("Opponent recieves double damage");//1
    }

    public override void OnPlayedCardDiscarded(CardInfo card)
    {
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        GameHandler.Instance.DamageOpponent(amount,true);
        ShakeRule(1);
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
    }

    public override void OnDefendCard(Card card, Card defendedWith)
    {
        if(!card.GetCardInfo()._opponentCard && !numbers.Contains(card.GetCardInfo()._number))
        {
            numbers.Add(card.GetCardInfo()._number);
        }
    }

    public override void OnPlayedCard(Card card)
    {
        if(!card.GetCardInfo()._opponentCard&&!numbers.Contains(card.GetCardInfo()._number))
        {
            numbers.Add(card.GetCardInfo()._number);
        }
    }

    public override void OnReverse(Card card)
    {
        if(!numbers.Contains(card.GetCardInfo()._number))
        {
            numbers.Add(card.GetCardInfo()._number);
        }
    }

    public async override void OnTurnEnd(int turnState)
    {
    }

    public override void SetDebuffs()
    {
        foreach(int num in this.numbers)
        {
            GameHandler.Instance.SetDebuffs(new string[]{"C"+num,"H"+num,"S"+num,"D"+num},true,false);
        }
        ShakeRule(0);
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
    }

    public override void OnHealPlayer(int amount, string fromMod = "")
    {
        
    }
}