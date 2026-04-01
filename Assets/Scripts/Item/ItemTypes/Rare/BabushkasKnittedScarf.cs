using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasKnittedScarf", menuName = "Items/Rare/BabushkasKnittedScarf")]
class BabushkasKnittedScarf : Item
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
        this.rarity = 1;
        this.boss = false;
        this.itemId = "BabushkasKnittedScarf";
        this.itemName="Babushka's KnittedScarf";
        this.toolTipDesc = $"{StylisticClass.HighLight}Negate all damage{StylisticClass.HighLightClose} dealt in the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} turn.";
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
        GameHandler.Instance.GetGameState()._undamagable[0]=true;
        return true;
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