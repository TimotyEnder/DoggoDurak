using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SadistSchnauzer", menuName = "Characters/SadistSchnauzer")]
public class SadistSchnauzer : Character
{
    public override void InitCharacter()
    {
        this.startingRubles = 20;
        this.characterId = "SadistSchnauzer";
        this.characterName = "Sadist Schnauzer";
    }

    public override List<Item> LoadItems()
    {
        List<Item> toRet = new List<Item> { ScriptableObject.CreateInstance<HeartyBeet>(), ScriptableObject.CreateInstance<SadismOfSurplus>() };
        foreach (Item i in toRet)
        {
            i.InitItem();
        }
        return toRet;

    }

}
