using UnityEngine;

[CreateAssetMenu(fileName = "WolfsGambit", menuName = "Items/Active-Legendary/WolfsGambit")]
class WolfsGambit : Item
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
        this.rarity = 2;
        this.boss = false;
        this.isActive = true;
        this.persistent = false;
        this.itemId = "WolfsGambit";
        this.itemName = "Wolf's Gambit";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} {StylisticClass.HighLight}double{StylisticClass.HighLightClose} the number of the {StylisticClass.HighLight}right-most{StylisticClass.HighLightClose} card and {StylisticClass.HighLight}discard{StylisticClass.HighLightClose} it. If it was a {StylisticClass.HighLight}face card{StylisticClass.HighLightClose}, {StylisticClass.HighLight}draw{StylisticClass.HighLightClose} 1 card";
    }

    public override bool OnActivate()
    {
        CardInfo cardToDouble = GameHandler.Instance.GetCardInHand(
            GameHandler.Instance.GetPlayerCardsInHand() - 1
        );
        bool wasFace = cardToDouble.IsFace();
        cardToDouble._number *= 2;
        cardToDouble._card.MakeCard(cardToDouble);
        GameHandler.Instance.PlayerDiscard(GameHandler.Instance.GetPlayerCardsInHand() - 1);
        if (wasFace)
        {
            GameHandler.Instance.Draw(1);
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
