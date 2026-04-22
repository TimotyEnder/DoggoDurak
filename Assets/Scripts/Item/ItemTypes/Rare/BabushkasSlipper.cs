using UnityEngine;

[CreateAssetMenu(fileName = "BabushkasSlipper", menuName = "Items/Rare/BabushkasSlipper")]
public class BabushkasSlipper : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "BabushkasSlipper";
        this.itemName = "Babushka's Slipper";
        this.toolTipDesc =
            $"{StylisticClass.ParryColor}{StylisticClass.ParryString}</color> effects +{StylisticClass.DamageNumber(1)}";
        AddSubtoolTip(ToolTip.SubtoolTips["Parry"]);
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        GameHandler.Instance.GetGameState()._modifierAddedEffect["Parry"]++;
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

    public override bool OnDamagePlayer(int amount, string fromMod = "")
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnDrawCard(CardInfo card)
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
