using UnityEngine;
[CreateAssetMenu(fileName = "PrivatizedCheckVoucher", menuName = "Items/Common/PrivatizedCheckVoucher")]
public class PrivatizedCheckVoucher : Item
{
    public override void InitItem()
    {
                this.rarity = 0;
        this.boss = false;
        this.itemId = "PrivatizedCheckVoucher";
        this.toolTipDesc = "One more item option will appear in the shop.";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._itemsShownInShop++;
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
