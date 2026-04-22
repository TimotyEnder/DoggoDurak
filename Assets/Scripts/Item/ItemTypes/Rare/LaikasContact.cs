using UnityEngine;

[CreateAssetMenu(fileName = "LaikasContact", menuName = "Items/Active-Rare/LaikasContact")]
class LaikasContact : Item
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
        this.itemId = "LaikasContact";
        this.itemName = "Laika's Contact";
        this.toolTipDesc =
            $"{StylisticClass.ActivateString} The righ=most card in your hand becomes a {StylisticClass.HighLight}Laika Card{StylisticClass.HighLightClose}. you heaal {StylisticClass.HighLight}5 hp{StylisticClass.HighLightClose}";
        AddSubtoolTip(ToolTip.SubtoolTips["Laika"]);
    }

    public override bool OnActivate()
    {
        CardInfo cardToConvert = GameHandler.Instance.GetCardInHand(
            GameHandler.Instance.GetPlayerCardsInHand() - 1
        );
        cardToConvert.MakeLaika();
        cardToConvert._card.MakeCard(cardToConvert);
        cardToConvert._card.Bling();
        GameHandler.Instance.HealPlayer(5);
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
