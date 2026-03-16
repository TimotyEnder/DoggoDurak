class PoisonCardMod : CardModifier
{
    public override bool OnAquire()
    {
        return false;
    }

    public override bool OnBeingDefended(Card cardDefendingThis)
    {
        return false;
    }

    public override bool OnCardDamage(int amount, Card card, int turnState)
    {
        if(turnState==1)
        {
            GameHandler.Instance.PoisonPlayer(card.GetCardInfo()._number/3);
        }
        else
        {
            GameHandler.Instance.PoisonOpponent(card.GetCardInfo()._number/3);
        }
        return true;
    }

    public override bool OnDefendCard(Card defendee, Card defended)
    {
        return false;
    }

    public override bool OnPlayedCard(Card card)
    {
        return false;
    }

    public override bool OnReverse(Card card)
    {
        return false;
    }
}