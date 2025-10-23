using UnityEngine;
[CreateAssetMenu(fileName = "CommodityExportLicense", menuName = "Items/Common/CommodityExportLicense")]
public class CommodityExportLicense : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "CommodityExportLicense";
        this.toolTipDesc = "More modifiers will appear on cards in shops";
    }

    public override void OnActivate()
    {
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._maxCardModsInShop++;
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
