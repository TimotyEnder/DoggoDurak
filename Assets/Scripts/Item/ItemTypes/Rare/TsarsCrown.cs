using UnityEngine;
[CreateAssetMenu(fileName = "TsarsCrown", menuName = "Items/Rare/TsarsCrown")]
public class TsarsCrown:Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.ItemId = "TsarsCrown";
    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number > 10 && c._number < 14) 
            {
                c._number++;
            }
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
