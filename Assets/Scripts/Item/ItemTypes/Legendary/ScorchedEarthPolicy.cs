using UnityEngine;
[CreateAssetMenu(fileName = "ScorchedEarthPolicy", menuName = "Items/Legendary/ScorchedEarthPolicy")]
class ScorchedEarthPolicy : Item
{
    private int damageDealtThisTurn;

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
        this.rarity = 2;
        this.boss = false;
        this.itemId = "ScorchedEarthPolicy";
        this.itemName="ScorchedEarthPolicy";
        this.toolTipDesc = $"At the end of the turn, the oppnent recieves {StylisticClass.DamageNumber(1)} per {StylisticClass.DamageNumber(2)} dealt by {StylisticClass.BurnColor}{StylisticClass.BurnString}</color>";
        AddSubtoolTip(Item.ItemSubtoolTips["Burn"]);
    }

    public override bool OnActivate()
    {
         return false;
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
        if(fromMod=="Burn")
        {
            damageDealtThisTurn+=amount;
        }
        return true;
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
        GameHandler.Instance.DamageOpponent(damageDealtThisTurn/2);
        return true;
    }
}