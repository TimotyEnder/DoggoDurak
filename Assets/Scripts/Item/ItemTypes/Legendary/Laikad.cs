using UnityEngine;
[CreateAssetMenu(fileName = "Laikad", menuName = "Items/Legendary/Laikad")]
class Laikad : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "Laikad";
        this.itemName="Laika'd!";
        this.toolTipDesc = $"Each time you play a {StylisticClass.HighLight}Laika Card{StylisticClass.HighLightClose} the highest card in your deck becomes a {StylisticClass.Laika}";
    }
    private void LaikaHandler(Card card)
    {
        if(!card.GetCardInfo()._opponentCard && card.GetCardInfo().IsLaika())
        {
            CardInfo highCard= GameHandler.Instance.GetGameState()._deck[0];
            foreach(CardInfo c in GameHandler.Instance.GetGameState()._deck)
            {
                if(c._number>highCard._number)
                {
                    highCard=c;
                }
            }
            highCard.MakeLaika();
        }
    }
    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        LaikaHandler(defendee);
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
        LaikaHandler(card);
    }

    public override void OnReverse(Card card)
    {
        
    }

    public override void OnTurnEnd(int turnState)
    {
        
    }

    public override int AddToDamagePlayer(int amount)
    {
        return 0;
    }

    public override int AddToDamageOpponent(int amount)
    {
        return 0;
    }
}