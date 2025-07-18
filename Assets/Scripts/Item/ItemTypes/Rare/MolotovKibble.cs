using UnityEngine;
[CreateAssetMenu(fileName = "MolotovKibble", menuName = "Items/Rare/MolotovKibble")]
public class MolotovKibble : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "MolotovKibble";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
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
        if (card.GetCard()._modifierStacks.ContainsKey("Burn"))
        {
            int posibility = Random.Range(1, 100);
            if (posibility <= 25) 
            {
                int cardsModded = 0;
                int it = 0;
                int amountToMod = 1;
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
        }
    }

    public override void OnReverse(Card card)
    {

    }
}
