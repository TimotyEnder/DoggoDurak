using UnityEngine;
[CreateAssetMenu(fileName = "ScorchedEarthPolicy", menuName = "Items/Legendary/ScorchedEarthPolicy")]
class ScorchedEarthPolicy : Item
{
    private int damageDealtThisTurn;

    public override int AddToDamageOpponent(int amount)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "ScorchedEarthPolicy";
        this.itemName="ScorchedEarthPolicy";
        this.toolTipDesc = $"At the end of the turn, the oppnent recieves {StylisticClass.DamageNumber(1)} per {StylisticClass.DamageNumber(2)} dea;t by {StylisticClass.BurnColor}{StylisticClass.BurnString}</color>";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        if(fromMod=="Burn")
        {
            damageDealtThisTurn+=amount;
        }
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEncounterStart()
    {
        
    }

    public override void OnEndEncounter()
    {
        
    }

    public override void OnHeal(int amount)
    {
        
    }

    public override void OnLoad()
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
        GameHandler.Instance.DamageOpponent(damageDealtThisTurn/2);
    }
}