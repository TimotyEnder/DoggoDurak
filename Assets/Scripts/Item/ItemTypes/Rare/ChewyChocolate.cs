using UnityEngine;
[CreateAssetMenu(fileName = "ChewyChocolate", menuName = "Items/Rare/ChewyChocolate")]
class ChewyChocolate : Item
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
        this.itemId = "ChewyChocolate";
        this.itemName="ChewyChocolate";
        this.toolTipDesc = $"{StylisticClass.HighLight}Your poison counters{StylisticClass.HighLightClose} no longer {StylisticClass.HighLight}decrease{StylisticClass.HighLightClose} at the end of turn.";
    }

    public override bool OnActivate()
    {
         return false;
    }

    public override bool OnAquire()
    {
        GameHandler.Instance.GetGameState()._poisonCountDown=false;
        return true;
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