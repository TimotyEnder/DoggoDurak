using UnityEngine;
[CreateAssetMenu(fileName = "Muzzle", menuName = "Items/Active-Legendary/Muzzle")]
public class Muzzle : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.isActive=true;
        this.persistent=true;
        this.itemId = "Muzzle";
        this.toolTipDesc =StylisticClass.ActivateString+"opponent cannot play face cards this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetDebuffs(new string[]{"C11","C12","C13","C14","D11","D12","D13","D14","H11","H12","H13","H14","S11","S12","S13","S14"},false,true);
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