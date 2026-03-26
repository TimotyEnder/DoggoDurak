using UnityEngine;
[CreateAssetMenu(fileName = "InvestmentFund", menuName = "Items/Active-Rare/InvestmentFund")]
class InvestmentFund : Item
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
        this.itemId = "InvestmentFund";
        this.itemName="InvestmentFund";
        this.isActive=true;
        this.persistent=false;
        this.toolTipDesc = $"{StylisticClass.ActivateString} {StylisticClass.HighLight}discard{StylisticClass.HighLightClose} the {StylisticClass.HighLight}right-most{StylisticClass.HighLightClose} card and {StylisticClass.HighLight}gain rubles equal to its number{StylisticClass.HighLightClose}.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.UpdateMoney(GameHandler.Instance.GetCardInHand(GameHandler.Instance.GetPlayerCardsInHand()-1)._number);
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetPlayerCardsInHand()-1);
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