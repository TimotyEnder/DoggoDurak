using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItem", menuName = "Items/Default")]
public class DefaultItem : Item
{
    public override void InitItem()
    {
        rarity = 0;
        boss = false;
        itemId = "DefaultItem";
        this.itemName = "?";
        this.toolTipDesc =
            "Hello Modders! Have your fun! Sorry shit might be a bit confusing but i am sur you will figure it out:)";
    }

    public override bool OnLoad()
    {
        return false;
    }

    public override bool OnAquire()
    {
        Debug.Log("Default Item On Aquire");
        return true;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
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

    public override bool OnHeal(int amount)
    {
        return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
    {
        return false;
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnEndEncounter()
    {
        return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
        return false;
    }

    public override bool OnCardAdded(CardInfo card)
    {
        return false;
    }

    public override bool OnEncounterStart()
    {
        return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod = "")
    {
        return false;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override bool OnDrawCard(CardInfo card)
    {
        return false;
    }
}
