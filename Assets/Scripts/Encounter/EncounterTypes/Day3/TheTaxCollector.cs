
using UnityEngine;
using Cysharp.Threading.Tasks;
[CreateAssetMenu(fileName = "TheTaxCollector", menuName = "Encounters/Day3/TheTaxCollector")]
public class TheTaxCollector : Encounter
{
    private int damageAccum;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Tax Collector";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        damageAccum=0;
        this.description="Will beat the money out of you if necessary!";
        hasRules=true;
    }
    public override void AddRules()
    {
        AddRule("For each "+StylisticClass.DamageNumber(5)+" you get dealt. you loose a ruble");//0
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
        damageAccum+=amount;
        int rubleLoss=damageAccum/5;
        damageAccum=damageAccum%5;
        if(rubleLoss>0)
        {
            GameHandler.Instance.UpdateMoney(-rubleLoss);
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

    public async override void OnTurnEnd(int turnState)
    {
    }

    public override void SetDebuffs()
    {
        
    }

    public override void OnHandCardDiscarded(CardInfo card)
    {
        
    }
}