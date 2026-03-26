using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasKnittedScarf", menuName = "Items/Rare/BabushkasKnittedScarf")]
class BabushkasKnittedScarf : Item
{
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "BabushkasKnittedScarf";
        this.itemName="Babushka's KnittedScarf";
        this.toolTipDesc = $"{StylisticClass.HighLight}Negate all damage{StylisticClass.HighLightClose} dealt in the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} turn.";
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

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEncounterStart()
    {
        GameHandler.Instance.GetGameState()._undamagable[0]=true;
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
        
    }
}