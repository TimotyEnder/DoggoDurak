using UnityEngine;

[CreateAssetMenu(fileName = "Balalaika", menuName = "Items/Legendary/Balalaika")]
public class Balalaika : Item
{
    private int _timesDamageDone;

    public override int AddToDamageOpponent(int amount, bool OnlyVisual = false)
    {
        _timesDamageDone++;
        if (this._timesDamageDone >= 3)
        {
            if (OnlyVisual)
            {
                _timesDamageDone--;
            }
            return amount * 2;
            //every third attack triple damage
        }
        if (OnlyVisual)
        {
            _timesDamageDone--;
        }
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual = false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "Balalaika";
        this.itemName = "Balalaika";
        this._timesDamageDone = 0;
        this.toolTipDesc = "Every third intance of damage you deal is tripled";
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
