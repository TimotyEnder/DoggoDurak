using UnityEngine;
[CreateAssetMenu(fileName = "ChocolateCandy", menuName = "Items/Consumable/ChocolateCandy")]
class ChocolateCandy : Item
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
        itemId = "ChocolateCandy";
        this.itemName="ChocolateCandy";
        this.toolTipDesc = $"{StylisticClass.ConsumeString} Until the end of the turn, all cards in your hand gain {StylisticClass.PoisonColor}{StylisticClass.PoisonString} {CardInfo.modifierToDescription["Poison"]}</color>";
    }

    public override void OnActivate()
    {
        for(int i = 0; i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo c= GameHandler.Instance.GetCardInHand(i);
            c.AddModifier("Poison",5,false);
            c._card.MakeCard(c);
            c._card.Bling();
        }
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
        
    }
}