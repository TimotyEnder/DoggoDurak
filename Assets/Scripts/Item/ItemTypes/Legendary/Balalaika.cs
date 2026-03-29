using UnityEngine;
[CreateAssetMenu(fileName = "Balalaika", menuName = "Items/Legendary/Balalaika")]
public class Balalaika : Item
{
    private int _timesDamageDone;

    public override int AddToDamageOpponent(int amount, bool OnlyVisual=false)
    {
        _timesDamageDone++;
        if (this._timesDamageDone >= 3) 
        {
            if(OnlyVisual){_timesDamageDone--;}
            return amount*2;
            //every third attack triple damage
        }
        if(OnlyVisual){_timesDamageDone--;}
        return 0;
    }

    public override int AddToDamagePlayer(int amount, bool OnlyVisual=false)
    {
        return 0;
    }

    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "Balalaika";
        this.itemName="Balalaika";
        this._timesDamageDone = 0;
        this.toolTipDesc = "Every third intance of damage you deal is tripled";
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
