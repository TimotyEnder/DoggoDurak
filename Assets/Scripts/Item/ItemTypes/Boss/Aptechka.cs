using UnityEngine;
[CreateAssetMenu(fileName = "Aptechka", menuName = "Items/Boss/Aptechka")]
class Aptechka : Item
{
    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.itemId = "Aptechka";
        this.itemName="State-of-the-art Aptechka";
        this.toolTipDesc = $"{StylisticClass.RestoringString} cards heal for {StylisticClass.HighLight}1/4{StylisticClass.HighLightClose} of their number value when {StylisticClass.HighLight}played{StylisticClass.HighLightClose}";

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
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo()._modifierStacks.ContainsKey("Restoring"))
        {
            GameHandler.Instance.HealPlayer(card.GetCardInfo()._number/4);
        }
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        
    }
}