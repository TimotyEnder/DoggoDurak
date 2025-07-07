using UnityEngine;
[CreateAssetMenu(fileName = "GrilledSteak", menuName = "Items/Rare/GrilledSteak")]
public class GrilledSteak : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.ItemId = "GrilledSteak";
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._maxhealth += 50;
        GameHandler.Instance.SetHealth(GameHandler.Instance.GetGameState()._maxhealth);
        //incase picked up while in card table
        GameHandler.Instance.HealPlayer(GameHandler.Instance.GetGameState()._maxhealth);
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
