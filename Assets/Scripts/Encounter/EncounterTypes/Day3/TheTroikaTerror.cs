
using UnityEngine;
using Cysharp.Threading.Tasks;
[CreateAssetMenu(fileName = "TheTroikaTerror", menuName = "Encounters/Day3/TheTroikaTerror")]
public class TheTroikaTerror : Encounter
{
    int instance=0;
    public override void InitEncounter()
    {
        day=1;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "The Troika Terror";
        goldRewardMod = 2f;
        SetHealth();
        initDeck(12,true,true,true,true);
        UpgradeRandomCardsInDeck(10,2);
        this.description="So inseparable that the even play together!";
        hasRules=true;
    }
    public override void AddRules()
    {
       AddRule("Each third instance of damage is tripled \n"+compile123text());//0
    }
    private string compile123text()
    {
        switch(instance)
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
    public override void OnPlayedCardDiscarded(CardInfo card)
    {
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        instance++;
        if(instance==3)
        {
            ShakeRule(0);
            GameHandler.Instance.DamageOpponent(amount,true,times:2);
            instance=0;
            ShakeRule(0);
        }
        UpdateRules();
    }

    public override void OnDamagePlayer(int amount, string fromMod)
    {
        instance++;
        if(instance==3)
        {
            ShakeRule(0);
            GameHandler.Instance.DamagePlayer(amount,true,times:2);
            instance=0;
            ShakeRule(0);
        }
        UpdateRules();
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