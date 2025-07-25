using UnityEngine;
[CreateAssetMenu(fileName = "Balalaika", menuName = "Items/Legendary/Balalaika")]
public class Balalaika : Item
{
    private int _timesDamageDone;
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "Balalaika";
        this._timesDamageDone = 0;
        this.toolTipDesc = "Every third intance of damage you deal is tripled";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {

    }

    public override void OnDamageOpponent(int amount)
    {
        _timesDamageDone++;
        if (this._timesDamageDone >= 3) 
        {
            GameHandler.Instance.DamageOpponent(amount * 2,true);
            //every third attack triple damage
        }
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

    }

    public override void OnReverse(Card card)
    {

    }
}
