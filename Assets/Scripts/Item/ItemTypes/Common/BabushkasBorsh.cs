using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasBorsh", menuName = "Items/Common/BabushkasBorsh")]
public class BabushkasBorsh : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.ItemId = "BabushkasBorsh";
    }

    public override void OnAquire()
    {
        int cardsModded = 0;
        int it = 0;
        int amountToMod = 3;
        string modifier = "Restoring";
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
