public class LaunchCodeLabrador : Encounter
{
    private int _turnsTillDamage;
    private int _damageToDelay;
    private int _damageLeft;
    public override void AddRules()
    {
        AddRule($"Every {_turnsTillDamage} turns, the opponent will deal 90% of your health as damage to you.");//0
        AddRule($"If you deal {_damageLeft} damage  to the opponent, this attack will be  delayed by 1 turn.");//1
        AddRule($"Every time you delay the opponent's attack, the damage required to do so increases");
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
    }

    public override void OnCardDrawn(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        _damageLeft-=amount;
        
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
        
    }
}