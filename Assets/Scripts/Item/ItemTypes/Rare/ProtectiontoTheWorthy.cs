using UnityEngine;

[CreateAssetMenu(fileName = "ProtectiontoTheWorthy", menuName = "Items/Rare/ProtectiontoTheWorthy")]
class ProtectiontoTheWorthy : Item
{
    private bool gained;
    private bool reset;
    private int shieldTurns;

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
        this.itemId = "ProtectiontoTheWorthy";
        this.itemName = "Protection to the Worthy!";
        this.toolTipDesc =
            $"{StylisticClass.HighLight}Once per encounter{StylisticClass.HighLightClose}, if you {StylisticClass.HighLight}successfully{StylisticClass.HighLightClose} defend an attack, gain {StylisticClass.ShieldNumber(5)} for the next {StylisticClass.HighLight}2 turns{StylisticClass.HighLightClose}";
        gained = false;
        shieldTurns = 0;
        reset = false;
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

    public override bool OnEncounterStart()
    {
        gained = false;
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
        if (shieldTurns <= 0 && reset)
        {
            GameHandler.Instance.SetPlayerShield(
                GameHandler.Instance.GetGameState()._playerShield - 5
            );
            reset = true;
        }
        else
        {
            shieldTurns--;
        }
        if (!gained && turnState == 1 && GameHandler.Instance.GetUnblockedCards() == 0)
        {
            gained = true;
            GameHandler.Instance.SetPlayerShield(
                GameHandler.Instance.GetGameState()._playerShield + 5
            );
            reset = true;
            shieldTurns = 1;
            return true;
        }
        return false;
    }
}
