using UnityEngine;
[CreateAssetMenu(fileName = "TrenchShovel", menuName = "Items/Consumable/TrenchShovel")]
class TrenchShovel : Item
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
        rarity = 0;
        boss = false;
        isActive=true;
        persistent=true;
        consumable=true;
        itemId = "TrenchShovel";
        this.itemName="TrenchShovel";
        this.toolTipDesc = $"{StylisticClass.ConsumeString} Recieve {StylisticClass.ShieldNumber(10)} {StylisticClass.HighLight}this turn{StylisticClass.HighLightClose}.";
        AddSubtoolTip(Item.ItemSubtoolTips["Shield"]);
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.SetPlayerShield(GameHandler.Instance.GetGameState()._playerShield+10);
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
        GameHandler.Instance.SetPlayerShield(GameHandler.Instance.GetGameState()._playerShield-10);
        return true;
    }
}