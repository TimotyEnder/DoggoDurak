using UnityEngine;

[CreateAssetMenu(fileName = "Stray'sLuckyCoin", menuName = "Items/Active-Rare/Stray'sLuckyCoin")]
public class StraysLuckyCoin : Item
{
    private int failPercentage=50;
     public override void InitItem()
    {
         this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "Stray'sLuckyCoin";
        this.persistent=false;
        UpdateToolTip();
    }
    public void UpdateToolTip() //this is  necesarry because the tooltip gets modified
    {
         this.toolTipDesc = StylisticClass.ActivateString+"A chance to either have two random cards discarded from you hand <b>("+(100-failPercentage)+"%)</b> or making the opponent discard 3 cards <b>("+(failPercentage)+"%)</b>. A given outcome increases its possibility to happen in the future.";
    }

    public override void OnActivate()
    {
        int roll= Random.Range(0,100);
        Debug.Log(roll);
        if(roll<failPercentage)
        {
            GameHandler.Instance.PlayerDiscard(Random.Range(0,GameHandler.Instance.GetCardsInHand()),2);
            failPercentage+=3;
        }
        else
        {
            GameHandler.Instance.OpponentDiscard(3);
            failPercentage-=3;
        }
        UpdateToolTip();
    }

    public override void OnAquire()
    {
        
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