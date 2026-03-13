using UnityEngine;

[CreateAssetMenu(fileName = "TheRedTape", menuName = "Items/Active-Rare/TheRedTape")]
public class TheRedTape : Item
{
     public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "TheRedTape";
        this.itemName="TheRedTape";
        this.persistent=true;
        this.toolTipDesc = StylisticClass.ActivateString+CardInfo.suitToColorToolText["H"]+" Hearts cannot be played this turn.";
    }

    public override void OnActivate()
    {
        GameHandler.Instance.SetDebuffs(new string[] {"H"},true,true);
    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod)
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