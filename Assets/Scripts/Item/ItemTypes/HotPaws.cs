using UnityEngine;
[CreateAssetMenu(fileName = "DoggoSnack", menuName = "Items/Common/HotPaws")]
public class HotPaws : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.ItemId = "HotPaws";
    }

    public override void OnAquire()
    {
        for (int i = 0; i < 5; i++) 
        {
            GameHandler.Instance.GetGameState()._deck[Random.Range(0, GameHandler.Instance.GetGameState()._deck.Count - 1)].addModifier("Burn");
        }
    }

    public override void OnDefendCard(Card defendee, Card defended)
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
