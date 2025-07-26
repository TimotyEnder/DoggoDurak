using UnityEngine;
[CreateAssetMenu(fileName = "DoggoSnack", menuName = "Items/Common/DoggoSnack")]
public class DoggoSnack : Item
{
    public override void InitItem()
    {
        this.rarity = 0;
        this.boss = false;
        this.itemId = "DoggoSnack";
        this.toolTipDesc = "Increases max health by 10";
    }

    public override void OnActivate()
    {

    }

    public override void OnAquire()
    {
        GameHandler.Instance.GetGameState()._maxhealth += 10;
        GameHandler.Instance.HealPlayer(GameHandler.Instance.GetGameState()._maxhealth);
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
