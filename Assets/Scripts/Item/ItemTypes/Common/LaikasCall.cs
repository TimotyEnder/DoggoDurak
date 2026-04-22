using UnityEngine;

[CreateAssetMenu(fileName = "LaikasCall", menuName = "Items/Common/LaikasCall")]
class LaikasCall : Item
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
        this.rarity = 0;
        this.boss = false;
        this.itemId = "LaikasCall";
        this.itemName = "Laika's Call";
        this.toolTipDesc =
            $"{StylisticClass.HighLight}1{StylisticClass.HighLightClose} random card  becomes a {StylisticClass.HighLight}Laika Card{StylisticClass.HighLightClose}";
        AddSubtoolTip(ToolTip.SubtoolTips["Laika"]);
    }

    public override bool OnActivate()
    {
        return false;
    }

    public override bool OnAquire()
    {
        CardInfo randomCard = GameHandler.Instance.GetGameState()._deck[
            Random.Range(0, GameHandler.Instance.GetGameState()._deck.Count)
        ];
        randomCard.MakeLaika();
        return true;
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
