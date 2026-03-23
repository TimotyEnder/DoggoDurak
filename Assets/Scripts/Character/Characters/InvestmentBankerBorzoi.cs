using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "InvestmentBankerBorzoi", menuName = "Characters/InvestmentBankerBorzoi")]
class InvestmentBankerBorzoi : Character
{
    public override void InitCharacter()
    {
        this.startingRubles=15;
        this.characterId="InvestmentBankerBorzoi";
        this.characterName="InvestmentBankerBorzoi";
    }

    public override List<Item> LoadItems()
    {
        List<Item> toRet=new List<Item>{new DachaDoorstep(), new InvestmentFund()};
        foreach(Item i in toRet)
        {
            i.InitItem();
        }
        return toRet;
    }
}