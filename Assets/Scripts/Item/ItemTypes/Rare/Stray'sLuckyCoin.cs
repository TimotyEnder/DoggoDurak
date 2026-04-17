using UnityEngine;

[CreateAssetMenu(fileName = "StraysLuckyCoin", menuName = "Items/Active-Rare/StraysLuckyCoin")]
public class StraysLuckyCoin : Item
{
    private int failPercentage = 50;

    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive = true;
        this.itemId = "StraysLuckyCoin";
        this.itemName = "Stray's Lucky Coin";
        this.persistent = false;
        UpdateToolTip();
    }

    public void UpdateToolTip() //this is  necesarry because the tooltip gets modified
    {
        this.toolTipDesc =
            StylisticClass.ActivateString
            + "Flip A Coin. Crest: have two random cards discarded from your hand <b>("
            + (100 - failPercentage)
            + "%)</b>  Grate: make the opponent discard 3 cards <b>("
            + (failPercentage)
            + "%)</b>. A given outcome increases its possibility to happen in the future.";
    }

    public override bool OnActivate()
    {
        int roll = Random.Range(0, 100);
        if (roll < failPercentage)
        {
            //In both cases wait for coin to spin then do the thing.
            GameHandler.Instance.SpinCoinWithVerdict(
                false,
                async () =>
                {
                    GameHandler.Instance.PlayerDiscard(
                        Random.Range(0, GameHandler.Instance.GetPlayerCardsInHand()),
                        2
                    );
                    failPercentage += 3;
                }
            );
        }
        else
        {
            GameHandler.Instance.SpinCoinWithVerdict(
                true,
                async () =>
                {
                    GameHandler.Instance.OpponentDiscard(3);
                    failPercentage -= 3;
                }
            );
        }
        UpdateToolTip();
        return true;
    }

    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
    {
        return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
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
}
