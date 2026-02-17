using UnityEngine;

[CreateAssetMenu(fileName = "TheMirDirective", menuName = "Items/Active-Rare/TheMirDirective")]
public class TheMirDirective : Item
{
     public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "TheMirDirective";
        this.persistent=true;
        this.toolTipDesc = StylisticClass.ActivateString+" Diamonds cannot be played this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetPlayPermissions(new string[] {"D"},true,true);
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