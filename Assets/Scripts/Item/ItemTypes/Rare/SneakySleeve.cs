using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "SneakySleeve", menuName = "Items/Rare/SneakySleeve")]
class SneakySleeve : Item
{
    private bool handReset = false;

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
        this.itemId = "SneakySleeve";
        this.itemName = "SneakySleeve";
        this.toolTipDesc =
            $"On the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} turn of each enoucnter, {StylisticClass.HighLight}draw 4{StylisticClass.HighLightClose} addicional cards";
        this.persistent = false;
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
        GameHandler.Instance.GetGameState()._handSize += 4;
        handReset = false;
        return true;
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
        if (!handReset)
        {
            GameHandler.Instance.GetGameState()._handSize -= 4;
            handReset = true;
        }
        return true;
    }
}
