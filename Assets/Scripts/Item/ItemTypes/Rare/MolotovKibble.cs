using UnityEngine;
[CreateAssetMenu(fileName = "MolotovKibble", menuName = "Items/Rare/MolotovKibble")]
public class MolotovKibble : Item
{
    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "MolotovKibble";
        this.itemName="MolotovKibble";
        this.toolTipDesc = "If you played a card with at least one "+StylisticClass.BurnColor+StylisticClass.BurnString+"</color> modifier there is a 25% chance another card in your draw pile gains "+StylisticClass.BurnColor+StylisticClass.BurnString+" 1"+"</color>";
        AddSubtoolTip(ToolTip.SubtoolTips["Burn"]);
    }

    public override bool OnActivate()
    {
          return false;
    }

    public override bool OnAquire()
    {
            return false;
    }

    public override bool OnCardAdded(CardInfo card)
    {
         return false;
    }

    public override bool OnDamageOpponent(int amount, string fromMod)
    {
         return false;
    }

    public override bool OnDamagePlayer(int amount, string fromMod="")
    {
         return false;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
         return false;
    }

    public override bool OnEncounterStart()
    {
         return false;
    }

    public override bool OnEndEncounter()
    {
         return false;
    }

    public override bool OnHeal(int amount)
    {
         return false;
    }

    public override bool OnLoad()
    {
           return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        if (card.GetCardInfo()._modifierStacks.ContainsKey("Burn"))
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
        return true;
    }

    public override bool OnReverse(Card card)
    {
          return false;
    }

    public override bool OnTurnEnd(int turnState)
    {
         return false;
    }
}
