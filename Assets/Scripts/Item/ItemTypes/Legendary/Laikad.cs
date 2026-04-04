using UnityEngine;
[CreateAssetMenu(fileName = "Laikad", menuName = "Items/Legendary/Laikad")]
class Laikad : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "Laikad";
        this.itemName="Laika'd!";
        this.toolTipDesc = $"Each time you play a {StylisticClass.HighLight}Laika Card{StylisticClass.HighLightClose} the highest card in your deck becomes a {StylisticClass.HighLight}Laika Card{StylisticClass.HighLightClose}";
        AddSubtoolTip(ToolTip.SubtoolTips["Laika"]);
    }
    private void LaikaHandler(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsLaika())
        {
            CardInfo highCard= GameHandler.Instance.GetGameState()._deck[0];
            foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
            {
                if(c._number>highCard._number)
                {
                    highCard=c;
                }
            }
            highCard.MakeLaika();
        }
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
        LaikaHandler(defendee);
        return true;
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
        LaikaHandler(card);
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

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }
}