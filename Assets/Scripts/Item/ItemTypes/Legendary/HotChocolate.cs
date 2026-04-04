using UnityEngine;
[CreateAssetMenu(fileName = "HotChocolate", menuName = "Items/Legendary/HotChocolate")]
class HotChocolate : Item
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
        this.rarity = 2;
        this.boss = false;
        this.itemId = "HotChocolate";
        this.itemName="HotChocolate";
        this.toolTipDesc = $"Your {StylisticClass.BurnColor}{StylisticClass.BurnString}</color> modifiers also apply {StylisticClass.HighLight}{StylisticClass.PoisonColor}{StylisticClass.PoisonString}</color> counters{StylisticClass.HighLightClose}.";
        AddSubtoolTip(Item.ItemSubtoolTips["Burn"]);
        AddSubtoolTip(Item.ItemSubtoolTips["Poison"]);
    }

    public override bool OnActivate()
    {
         return false;
    }

    public override bool OnAquire()
    {
        GameHandler.Instance.GetGameState()._burnPoison=true;
        return  true;
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