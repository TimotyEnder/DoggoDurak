using UnityEngine;
using UnityEngine.InputSystem.DualShock;
[CreateAssetMenu(fileName = "TheBreadlineBargain", menuName = "Items/Rare/TheBreadlineBargain")]
public class TheBreadlineBargain : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.ItemId = "TheBreadlineBargain";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._handSize += 1;
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
