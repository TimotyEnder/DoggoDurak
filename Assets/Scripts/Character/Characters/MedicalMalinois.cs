using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "MedicalMalinois", menuName = "Characters/MedicalMalinois")]
class MedicalMalinois : Character
{
    public override void InitCharacter()
    {
        this.startingRubles=20;
        this.characterId="MedicalMalinois";
        this.characterName="MedicalMalinois";
    }

    public override List<Item> LoadItems()
    {
        List<Item> toRet=new List<Item>{new BabushkasBorsh(), new NaZdorovie()};
        foreach(Item i in toRet)
        {
            i.InitItem();
        }
        return toRet;
    }
}