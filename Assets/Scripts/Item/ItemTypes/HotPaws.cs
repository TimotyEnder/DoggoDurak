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
        int cardsModded = 0;
        int it = 0;
        int amountToMod = 5;
        string modifier = "Burn";
        while (it < GameHandler.Instance.GetGameState()._deck.Count && cardsModded < amountToMod)
        {
            CardInfo cardToMod = GameHandler.Instance.GetGameState()._deck[Random.Range(0, GameHandler.Instance.GetGameState()._deck.Count - 1)];
            if (!cardToMod._modifierStacks.ContainsKey(modifier))
            {
                cardToMod.AddModifier(modifier);
                cardsModded++;
            }
            it++;
        }
        for (int j = 0; j < amountToMod - cardsModded; j++) //try top add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
        {
            CardInfo cardToMod = GameHandler.Instance.GetGameState()._deck[Random.Range(0, GameHandler.Instance.GetGameState()._deck.Count - 1)];
            cardToMod.AddModifier(modifier);
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
