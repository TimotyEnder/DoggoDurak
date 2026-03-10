using UnityEngine;
[CreateAssetMenu(fileName = "ChewToy", menuName = "Items/Rare/ChewToy")]
class ChewToy : Item
{
    public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.itemId = "ChewToy";
        this.toolTipDesc = $"At the end of each encounter heal {StylisticClass.HighLight}5%{StylisticClass.HighLightClose} hp";
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

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEndEncounter()
    {
        GameHandler.Instance.HealPlayer((int)(GameHandler.Instance.GetGameState()._maxhealth*0.05f));
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