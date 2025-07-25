using UnityEngine;
[CreateAssetMenu(fileName = "DoctorsSausage", menuName = "Items/Rare/DoctorsSausage")]
public class DoctorsSausage : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "DoctorsSausage";
        this.toolTipDesc = "+1 value for each card in your deck";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number < 14) 
            {
                c._number++;
            }
        }
    }

    public override void OnDamageOpponent(int amount)
    {
        
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
