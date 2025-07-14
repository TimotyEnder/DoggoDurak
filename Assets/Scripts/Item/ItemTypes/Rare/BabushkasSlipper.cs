using UnityEngine;
[CreateAssetMenu(fileName = "BabushkasSlipper", menuName = "Items/Rare/BabushkasSlipper")]
public class BabushkasSlipper : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.ItemId = "BabushkasSlipper";
    }

    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number % 2 == 0 && c._number < 11 && !c._modifierStacks.ContainsKey("Parry")) 
            {
                c.AddModifier("Parry");
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
