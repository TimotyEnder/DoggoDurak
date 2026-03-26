using UnityEngine;
[CreateAssetMenu(fileName = "FirstAidKit", menuName = "Items/Consumable/FirstAidKit")]
class FirstAidKit : Item
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
        rarity = 0;
        boss = false;
        isActive=true;
        persistent=true;
        consumable=true;
        itemId = "FirstAidKit";
        this.itemName="FirstAidKit";
        this.toolTipDesc = $"{StylisticClass.ConsumeString} Until the end of the turn, all cards in your hand gain {StylisticClass.RestoringColor}{StylisticClass.RestoringString} {CardInfo.modifierToDescription["Restoring"]}</color>";
    }

    public override void OnActivate()
    {
        for(int i = 0; i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo c= GameHandler.Instance.GetCardInHand(i);
            c.AddModifier("Restoring",5,false);
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