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
        this.characterName="Malinois";
    }

    public override List<Item> LoadItems()
    {
        List<Item> toRet=new List<Item>{ScriptableObject.CreateInstance<BabushkasBorsh>(), ScriptableObject.CreateInstance<NaZdorovie>()};
        foreach(Item i in toRet)
        {
            i.InitItem();
        }
        return toRet;
    }
}