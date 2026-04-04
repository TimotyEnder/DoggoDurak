using UnityEngine;
[CreateAssetMenu(fileName = "BurningClaws", menuName = "Items/Rare/BurningClaws")]
public class BurningClaws : Item
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
        this.itemId = "BurningClaws";
        this.itemName="BurningClaws";
        this.toolTipDesc = $"{StylisticClass.BurnColor}{StylisticClass.BurnString}</color> effects +{StylisticClass.DamageNumber(1)}";
        AddSubtoolTip(ToolTip.SubtoolTips["Burn"]);
    }

    public override bool OnActivate()
    {
          return false;
    }

    public override bool OnAquire()
    {
        GameHandler.Instance.GetGameState()._modifierAddedEffect["Burn"]++;
        return true;
    }

    public override bool OnCardAdded(CardInfo card)
    {
         return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
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
