using UnityEngine;
[CreateAssetMenu(fileName = "AviatorsHelmet", menuName = "Items/Rare/AviatorsHelmet")]
public class AviatorsHelmet : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "AviatorsHelmet";
        this.itemName="Aviator's Helmet";
        this.toolTipDesc = $"{StylisticClass.BounceColor}{StylisticClass.BounceString}</color> effects +{StylisticClass.DamageNumber(1)}";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._modifierAddedEffect["Bounce"]++;
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
    {
        
    }

    public override void OnDamagePlayer(int amount, string fromMod = "")
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
