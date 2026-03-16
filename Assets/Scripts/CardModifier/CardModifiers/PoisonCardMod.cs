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

    public override bool OnCardDamage(int amount, Card card)
    {
        if(card.GetCardInfo()._opponentCard)
        {
            //add player poison counter handling
        }
        else
        {
            GameHandler.Instance.GetCurrEncounter().AddPoisonCounter(1);
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