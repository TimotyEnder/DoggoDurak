using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpikedShepherded", menuName = "Encounters/Day1/SpikedShepherded")]
public class SpikedShepherded : Encounter
{
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Spiked Shepherded";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true);
        AddRandomModifierToDeck(20,"Spiky");
        this.description="Spiky but brittle";
        hasRules=true;
        AddRule("The opponent recieves double damage"); //0
    }

    public override void OnDamageOpponent(int amount)
    {
        GameHandler.Instance.DamageOpponent(amount,true);
        ShakeRule(0);
    }

    public override void OnDamagePlayer(int amount)
    {
        
    }

    public override void OnDefendCard(Card card, Card defendedWith)
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

    public override void SetPlayPermissions()
    {
        
    }
}