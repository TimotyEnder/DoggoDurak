using UnityEngine;
[CreateAssetMenu(fileName = "Tsh4", menuName = "Items/Rare/Tsh4")]
class Tsh4 : Item
{
    int turns;
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "Tsh4";
        this.itemName="Tsh=4";
        this.toolTipDesc = $"For the first 3 turns, recieve {StylisticClass.DamageNumber(5)} less from all sources.";
        turns=0;
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
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEncounterStart()
    {
        GameHandler.Instance.GetGameState()._playedDamageReduction+=5;
        turns=0;
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
        turns++;
        if(turns>=3)
        {
            GameHandler.Instance.GetGameState()._playedDamageReduction-=5;
        }
    }
}