using UnityEngine;
[CreateAssetMenu(fileName = "RedCaviar", menuName = "Items/Rare/RedCaviar")]
public class RedCaviar : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "RedCaviar";
        this.toolTipDesc = "+1 value to all red cards";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            if (c._number < 14 && (c._suit=="D"|| c._suit == "H"))
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
