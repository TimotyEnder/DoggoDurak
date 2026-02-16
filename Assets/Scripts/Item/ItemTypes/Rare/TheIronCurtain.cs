using UnityEngine;

[CreateAssetMenu(fileName = "TheIronCurtain", menuName = "Items/Active-Rare/TheIronCurtain")]
public class TheIronCurtain : Item
{
    public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "TheIronCurtain";
        this.toolTipDesc = StylisticClass.ActivateString+" Spades cannot be played this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetPlayPermissions(new string[] {"S"},true,true);
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