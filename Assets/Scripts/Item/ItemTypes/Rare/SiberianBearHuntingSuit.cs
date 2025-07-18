using UnityEngine;
[CreateAssetMenu(fileName = "SiberianBearHuntingSuit", menuName = "Items/Rare/SiberianBearHuntingSuit")]
public class SiberianBearHuntingSuit : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "SiberianBearHuntingSuit";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number % 2 != 0 && c._number<11) 
            {
                c.AddModifier("Spiky");
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
