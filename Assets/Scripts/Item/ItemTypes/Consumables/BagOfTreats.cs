using UnityEngine;
[CreateAssetMenu(fileName = "BagOfTreats", menuName = "Items/Consumable/BagOfTreats")]
class BagOfTreats : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        isActive=true;
        persistent=true;
        consumable=true;
        itemId = "BagOfTreats";
        this.itemName="BagOfTreats";
        this.toolTipDesc = $"Each turn heal {StylisticClass.HighLight}1hp{StylisticClass.HighLightClose}. This amount cannot be increased. {StylisticClass.ConsumeString} gain {StylisticClass.HighLight}20hp{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.HealPlayer(20);
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
        GameHandler.Instance.HealPlayer(1,true);
    }
}