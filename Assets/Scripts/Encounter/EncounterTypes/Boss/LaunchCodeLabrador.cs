
using UnityEngine;
[CreateAssetMenu(fileName = "LaunchCodeLabrador", menuName = "Encounters/Boss-Day3/LaunchCodeLabrador")]
public class LaunchCodeLabrador : Encounter
{
    private int _turnsTillDamage;
    private int _maxTurnsTillDamage;
    private int _damageToDelay;
    private int _damageLeft;
    public override void AddRules()
    {
        AddRule($"After {StylisticClass.HighLight}{_turnsTillDamage}{StylisticClass.HighLightClose} turns, the opponent will deal 90% of your max health as damage to you.");//0
        AddRule($"If you deal {StylisticClass.DamageNumber(_damageLeft)}  to the opponent, this attack will be  delayed by {StylisticClass.HighLight}1 turn.{StylisticClass.HighLightClose}");//1
        AddRule($"Every time you delay the opponent's attack, the damage required to do so increases");
    }

    public override int AddToDamageOpponent(int amount, string fromMod = "")
    {
        return amount;
    }

    public override int AddToDamagePlayer(int amount, string fromMod = "")
    {
        return amount;
    }

    public override void InitEncounter()
    {
        day=2;
        boss=true;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Launch Code Labrador";
        goldRewardMod = 2f*(GameHandler.Instance.GetGameState()._day+1);
        SetHealth();
        initDeck(14,true,true,true,true);
        this.description="That red button sure looks menacing...";
        hasRules=true;
        _maxTurnsTillDamage=4;
        _turnsTillDamage=_maxTurnsTillDamage;
        _damageToDelay=10;
        _damageLeft=_damageToDelay;
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        _damageLeft-=amount;
        if(_damageLeft<=0)
        {
            _turnsTillDamage++;
            _damageToDelay++;
            _damageLeft=_damageToDelay;
            UpdateRules();
            ShakeRule(1);
            ShakeRule(2);
        }
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
        _turnsTillDamage--;
        if(_turnsTillDamage<=0)
        {
            int damageCal=(int)(GameHandler.Instance.GetGameState()._maxhealth*0.9f);
            GameHandler.Instance.DamagePlayer(damageCal);
            UpdateRules();
            ShakeRule(0);
        }
        else
        {
            UpdateRules();
            ShakeRule(0);
        }
    }

    public override void SetDebuffs()
    {
        
    }
}