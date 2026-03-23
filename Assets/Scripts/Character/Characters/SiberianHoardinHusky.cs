using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "SiberianHoardinHusky", menuName = "Characters/SiberianHoardinHusky")]
class SiberianHoardinHusky : Character
{
    public override void InitCharacter()
    {
        this.startingRubles=30;
        this.characterId="SiberianHoardinHusky";
        this.characterName="Siberian Hoardin' Husky";
    }

    public override List<Item> LoadItems()
    {
        List<Item> toRet=new List<Item>{new ClippedClaws(), new HoardingHabit()};
        foreach(Item i in toRet)
        {
            i.InitItem();
        }
        return toRet;
    }
}