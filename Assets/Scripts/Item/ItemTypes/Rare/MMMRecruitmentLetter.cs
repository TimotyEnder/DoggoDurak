using UnityEngine;
[CreateAssetMenu(fileName = "MMMRecruitmentLetter", menuName = "Items/Rare/MMMRecruitmentLetter")]
public class MMMRecruitmentLetter : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "MMM RecruitmentLetter";
        this.toolTipDesc = "For each encounter get a bonus ruble reward for each additional card in your deck";
    }

    public override void OnActivate()
    {
    }

    public override void OnAquire()
    {
        GameHandler.Instance.AddCurrencyCalculator(new CardHoarderCC());
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