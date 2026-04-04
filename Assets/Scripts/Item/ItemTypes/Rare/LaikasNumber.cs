using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "LaikasNumber", menuName = "Items/Rare/LaikasNumber")]
class LaikasNumber : Item
{
    private int _turnsPlayed=0;

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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "LaikasNumber";
        this.itemName="Laika's Number";
        this.toolTipDesc = $"On the {StylisticClass.HighLight}5th turn{StylisticClass.HighLightClose} of an encounter, {StylisticClass.HighLight}add a Laika Card{StylisticClass.HighLightClose} to your deck";
        AddSubtoolTip(Item.ItemSubtoolTips["Laika"]);
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
         return false;
    }

    public override bool OnReverse(Card card)
    {
         return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
        _turnsPlayed++;
        if(_turnsPlayed==5)
        {
            GameHandler.Instance.AddCardToDeck(new CardInfo("L",0));
        }
        return true;
    }
}