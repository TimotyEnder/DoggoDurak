using UnityEngine;
[CreateAssetMenu(fileName = "BlackCaviar", menuName = "Items/Legendary/BlackCaviar")]
public class BlackCaviar : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "BlackCaviar";
        this.toolTipDesc = "+2 value to all black cards";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number < 13 && (c._suit == "S" || c._suit == "C"))
            {
                c._number += 2;
            }
            else if (c._number < 14 && (c._suit == "S" || c._suit == "C"))
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
