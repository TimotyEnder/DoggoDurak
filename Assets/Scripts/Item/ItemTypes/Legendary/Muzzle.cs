using UnityEngine;
[CreateAssetMenu(fileName = "Muzzle", menuName = "Items/Active-Legendary/Muzzle")]
public class Muzzle : Item
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
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.persistent=true;
        this.itemId = "Muzzle";
        this.itemName="Muzzle";
        this.toolTipDesc =StylisticClass.ActivateString+"opponent cannot play face cards this turn.";
    }

    public override bool OnActivate()
    {
        GameHandler.Instance.SetDebuffs(new string[]{"C11","C12","C13","C14","D11","D12","D13","D14","H11","H12","H13","H14","S11","S12","S13","S14"},false,true);
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