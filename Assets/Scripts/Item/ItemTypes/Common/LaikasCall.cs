
using UnityEngine;
[CreateAssetMenu(fileName = "LaikasCall", menuName = "Items/Common/LaikasCall")]
class LaikasCall : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "LaikasCall";
        this.itemName="Laika's Call";
        this.toolTipDesc = $"{StylisticClass.HighLight}1{StylisticClass.HighLightClose} random card  becomes a {StylisticClass.Laika}";
    }

    public override void OnActivate()
    {
        
    }

    public override void OnAquire()
    {
        CardInfo randomCard= GameHandler.Instance.GetGameState()._deck[Random.Range(0,GameHandler.Instance.GetGameState()._deck.Count)];
        randomCard.MakeLaika();
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