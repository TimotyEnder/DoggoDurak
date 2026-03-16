using UnityEngine;
[CreateAssetMenu(fileName = "ContrabandChocolateBar", menuName = "Items/Common/ContrabandChocolateBar")]
class ContrabandChocolateBar : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "ContrabandChocolateBar";
        this.itemName="ContrabandChocolateBar";
        this.toolTipDesc = "5 random cards gain "+StylisticClass.PoisonColor+StylisticClass.PoisonString+" 1"+CardInfo.modifierToDescription["Poison"]+"</color>";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        int cardsModded = 0;
        int it = 0;
        int amountToMod = 5;
        string modifier = "Poison";
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

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEncounterStart()
    {
        
    }

    public override void OnEndEncounter()
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

    public override void OnTurnEnd(int turnState)
    {
        
    }
}