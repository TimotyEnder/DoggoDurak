using UnityEngine;

[CreateAssetMenu(fileName = "TheIronCurtain", menuName = "Items/Active-Rare/TheIronCurtain")]
public class TheIronCurtain : Item
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
        this.isActive=true;
        this.itemId = "TheIronCurtain";
        this.itemName="TheIronCurtain";
        this.persistent=true;
        this.toolTipDesc = StylisticClass.ActivateString+" Spades cannot be played this turn.";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.SetDebuffs(new string[] {"S"},true,true);
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

    public override bool OnDamageOpponent(int amount, string fromMod)
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
         return false;
    }
}