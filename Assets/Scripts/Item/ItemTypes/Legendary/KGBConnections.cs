using UnityEngine;
[CreateAssetMenu(fileName = "KGBConnections", menuName = "Items/Legendary/KGBConnections")]
public class KGBConnections : Item
{
    public override void InitItem()
    {
        this.rarity = 2;
        this.boss = false;
        this.itemId = "KGBConnections";
        this.toolTipDesc = "All face crads gain "+StylisticClass.CrippleColor+StylisticClass.CrippleString+" 1 (Makes opponent discard 1 card for each cripple modifier on the card)</color>";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck) 
        {
            if (c._number > 10) 
            {
                c.AddModifier("Cripple");
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
