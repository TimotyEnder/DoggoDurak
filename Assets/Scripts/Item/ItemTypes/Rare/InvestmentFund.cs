using UnityEngine;
[CreateAssetMenu(fileName = "InvestmentFund", menuName = "Items/Active-Rare/InvestmentFund")]
class InvestmentFund : Item
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "InvestmentFund";
        this.itemName="InvestmentFund";
        this.isActive=true;
        this.persistent=false;
        this.toolTipDesc = $"{StylisticClass.ActivateString} {StylisticClass.HighLight}discard{StylisticClass.HighLightClose} the {StylisticClass.HighLight}right-most{StylisticClass.HighLightClose} card and {StylisticClass.HighLight}gain {StylisticClass.RubleSign} equal to its number{StylisticClass.HighLightClose}.";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.UpdateMoney(GameHandler.Instance.GetCardInHand(GameHandler.Instance.GetPlayerCardsInHand()-1)._number);
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetPlayerCardsInHand()-1);
        return true;
    }

    public override bool OnAquire()
    {
            return false;
    }

    public override bool OnCardAdded(CardInfo card)
    {
         return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod = "")
    {
         return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod="")
    {
         return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
          return false;
    }

    public override bool OnEncounterStart()
    {
         return false;
    }

    public override bool OnEndEncounter()
    {
         return false;
    }

    public override bool OnHeal(int amount)
    {
         return false;
    }

    public override bool OnLoad()
    {
         return false;
    }

    public override bool OnPlayedCard(Card card)
    {
         return false;
    }

    public override bool OnReverse(Card card)
    {
         return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
         return false;
    }
}