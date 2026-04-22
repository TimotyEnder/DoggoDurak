using UnityEngine;

[CreateAssetMenu(fileName = "PrisonerTransfer", menuName = "Items/Active-Rare/PrisonerTransfer")]
class PrisonerTransfer : Item
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
        this.isActive = true;
        this.itemId = "PrisonerTransfer";
        this.itemName = "Prisoner Transfer";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} Until the end of the turn, {StylisticClass.HighLight}debuffed cards{StylisticClass.HighLightClose} are no longer {StylisticClass.HighLight}debuffed{StylisticClass.HighLightClose}, and cards that are not {StylisticClass.HighLight}debuffed{StylisticClass.HighLightClose} become {StylisticClass.DebuffedDesc}";
    }

    public override bool OnActivate()
    {
        for (int i = 0; i < GameHandler.Instance.GetPlayerCardsInHand(); i++)
        {
            CardInfo card = GameHandler.Instance.GetCardInHand(i);
            if (card._card.IsDebuffed())
            {
                card._card.SetDebuffed(false);
            }
            else
            {
                card._card.SetDebuffed(false);
            }
        }
        return true;
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
