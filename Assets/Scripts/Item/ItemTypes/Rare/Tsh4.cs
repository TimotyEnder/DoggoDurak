using UnityEngine;

[CreateAssetMenu(fileName = "Tsh4", menuName = "Items/Rare/Tsh4")]
class Tsh4 : Item
{
    int turns;

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
        this.itemId = "Tsh4";
        this.itemName = "Tsh-4";
        this.toolTipDesc = $"For the first 3 turns, recieve {StylisticClass.ShieldNumber(5)}";
        AddSubtoolTip(ToolTip.SubtoolTips["Shield"]);
        turns = 0;
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
        GameHandler.Instance.SetPlayerShield(GameHandler.Instance.GetGameState()._playerShield + 5);
        turns = 0;
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
        turns++;
        if (turns >= 3)
        {
            GameHandler.Instance.SetPlayerShield(
                GameHandler.Instance.GetGameState()._playerShield - 5
            );
            return true;
        }
        return false;
    }
}
