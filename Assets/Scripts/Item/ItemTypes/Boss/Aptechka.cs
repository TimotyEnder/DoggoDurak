using UnityEngine;
[CreateAssetMenu(fileName = "Aptechka", menuName = "Items/Boss/Aptechka")]
class Aptechka : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 3;
        this.boss = true;
        this.itemId = "Aptechka";
        this.itemName="State-of-the-art Aptechka";
        this.toolTipDesc = $"{StylisticClass.RestoringColor}{StylisticClass.RestoringString}</color> cards heal for {StylisticClass.HighLight}1/4{StylisticClass.HighLightClose} of their number value when {StylisticClass.HighLight}played{StylisticClass.HighLightClose}";
        AddSubtoolTip(ToolTip.SubtoolTips["Restoring"]);
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

    public override bool OnDamagePlayer(int amount, string fromMod="")
    {
         return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
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
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo()._modifierStacks.ContainsKey("Restoring"))
        {
            GameHandler.Instance.HealPlayer(card.GetCardInfo()._number/4);
            card.SpawnModifierEffect(new CardModifierContainer("Restoring"));
        }
        return true;
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