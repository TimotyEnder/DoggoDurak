using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "SneakySleeve", menuName = "Items/Rare/SneakySleeve")]
class SneakySleeve : Item
{
    private bool handReset=false;
    public override void InitItem()
    {
        this.rarity = 1;
        this.boss = false;
        this.itemId = "SneakySleeve";
        this.itemName="SneakySleeve";
        this.toolTipDesc=$"On the {StylisticClass.HighLight}first{StylisticClass.HighLightClose} turn of each enoucnter, {StylisticClass.HighLight}draw 4{StylisticClass.HighLightClose} addicional cards";
        this.persistent=false;
    }

    public override void OnActivate()
    {
        
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

    public override void OnEncounterStart()
    {
        GameHandler.Instance.GetGameState()._handSize+=4;
        handReset=false;
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
        if (!handReset)
        {
             GameHandler.Instance.GetGameState()._handSize-=4;
             handReset=true;
        }
    }
}