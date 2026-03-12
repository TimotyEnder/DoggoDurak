using UnityEngine;
[CreateAssetMenu(fileName = "PrisonerTransfer", menuName = "Items/Active-Rare/PrisonerTransfer")]
class PrisonerTransfer : Item
{
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.isActive=true;
        this.itemId = "PrisonerTransfer";
        this.itemName="Prisoner Transfer";
        this.toolTipDesc = $"{StylisticClass.ActivateString} Until the end of the turn, {StylisticClass.HighLight}debuffed cards{StylisticClass.HighLightClose} are no longer {StylisticClass.HighLight}debuffed{StylisticClass.HighLightClose}, and cards that are not {StylisticClass.HighLight}debuffed{StylisticClass.HighLightClose} become {StylisticClass.Debuffed}"; 
    }

    public override void OnActivate()
    {
        for(int i=0;i<GameHandler.Instance.GetPlayerCardsInHand();i++)
        {
            CardInfo card= GameHandler.Instance.GetCardInHand(i);
            if(GameHandler.Instance.IsCardnotDebuffed(card,0))
            {
                GameHandler.Instance.SetDebuffs(new string[]{$"{card._suit}{card._number}"},true,false);
            }
            else
            {
                GameHandler.Instance.SetDebuffs(new string[]{$"{card._suit}{card._number}"},false,false);
            }
            card._card.CheckDebuffVisual();
            card._card.Bling();
        }
    }

    public override void OnAquire()
    {
        
    }

    public override void OnCardAdded(CardInfo card)
    {
        
    }

    public override void OnDamageOpponent(int amount, string fromMod = "")
    {
        
    }

    public override void OnDefendCard(Card defendee, Card defended)
    {
        
    }

    public override void OnEndEncounter()
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

    public override void OnTurnEnd(int turnState)
    {
        
    }
}