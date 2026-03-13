using UnityEngine;
[CreateAssetMenu(fileName = "LaikasContact", menuName = "Items/Active-Rare/LaikasContact")]
class LaikasContact : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "LaikasContact";
        this.itemName="Laika's Contact";
        this.toolTipDesc = $"{StylisticClass.ActivateString} The righ=most card in your hand becomes a {StylisticClass.Laika}. you heaal {StylisticClass.HighLight}5 hp{StylisticClass.HighLightClose}";
    }

    public override void OnActivate()
    {
        CardInfo cardToConvert=GameHandler.Instance.GetCardInHand(GameHandler.Instance.GetPlayerCardsInHand()-1);
        cardToConvert.MakeLaika();
        cardToConvert._card.MakeCard(cardToConvert);
        cardToConvert._card.Bling();
        GameHandler.Instance.HealPlayer(5);
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