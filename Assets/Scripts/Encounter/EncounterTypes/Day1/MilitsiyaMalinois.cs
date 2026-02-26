using System.Data;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MilitsiyaMalinois", menuName = "Encounters/Day1/MilitsiyaMalinois")]
public class MilitsiyaMalinois : Encounter
{
    private int _numberCannotBePlayed;
    public override void InitEncounter()
    {
        day=0;
        boss=false;
        trumpSuit = 'R';
        icon = null;
        encounterName = "Militsiya Malinois";
        goldRewardMod = 1f;
        SetHealth();
        initDeck(10,true,true,true,true);
        AddRandomModifierToDeck(10,"Restoring");
        this.description="Enforces the law!";
        _numberCannotBePlayed=Random.Range(6,11);
        hasRules=true;
        AddRule("Cards with the number "+StylisticClass.HighLight+_numberCannotBePlayed+StylisticClass.HighLightClose +" are "+StylisticClass.Debuffed); //0
    }
    public override void OnDamageOpponent(int amount)
    {
        
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
        GameHandler.Instance.SetDebuffs(new string[]{"C"+_numberCannotBePlayed,"D"+_numberCannotBePlayed,"H"+_numberCannotBePlayed,"S"+_numberCannotBePlayed},true,true);
        ShakeRule(0);
    }
}