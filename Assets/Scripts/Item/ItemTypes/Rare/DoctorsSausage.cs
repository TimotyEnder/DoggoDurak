using UnityEngine;
[CreateAssetMenu(fileName = "DoctorsSausage", menuName = "Items/Rare/DoctorsSausage")]
public class DoctorsSausage : Item
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
        this.itemId = "DoctorsSausage";
        this.itemName="DoctorsSausage";
        this.toolTipDesc = "+1 for each numbered card in your deck";
    }

    public override bool OnActivate()
    {
          return false;
    }

    public override bool OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if(!c.IsFace())
            {
                c._number++;
            }
        }
        return true;
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
