using UnityEngine;
[CreateAssetMenu(fileName = "ThePtyuchFold", menuName = "Items/Active-Rare/ThePtyuchFold")]
public class ThePtyuchFold : Item
{
    public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "ThePtyuchFold";
        this.persistent=true;
        this.toolTipDesc = StylisticClass.ActivateString+" Clubs cannot be played this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetPlayPermissions(new string[] {"C"},true,true);
    }

    public override void OnAquire()
    {
        
    }

    public override void OnDamageOpponent(int amount)
    {

    }

    public override void OnDefendCard(Card defendee, Card defended)
    {

    }

    public override void OnHeal(int amount)
    {

    }

    public override void OnLoad()
    {

    }

    public override void OnPlayedCard(Card card)
    {

    }

    public override void OnReverse(Card card)
    {

    }
}