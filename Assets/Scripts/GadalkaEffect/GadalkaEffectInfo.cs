using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GadalkaEffect", menuName = "Scriptable Objects/GadalkaEffect")]
[Serializable]
public abstract class GadalkaEffectInfo:ScriptableObject
{
    protected string descriptionText;
    protected bool blessing;
    protected int cost;
    public abstract void InitEffect();
    public abstract void ExecuteEffect();
    public string GetDescription()
    {
        return descriptionText;
    }
    public bool IsBlessing()
    {
        return blessing;
    }
    public int GetCost()
    {
        return this.cost;
    }
    protected void AddModToRandomCards(int amountToMod,string modifier,List<CardInfo> list=null)
    {
        int cardsModded = 0;
        int it = 0;
        if(list==null)
        {
            list=  GameHandler.Instance.GetGameState()._deck;
        }
        while (it < list.Count && cardsModded < amountToMod)
        {
            CardInfo cardToMod = list[UnityEngine.Random.Range(0, list.Count - 1)];
            if (!cardToMod._modifierStacks.ContainsKey(modifier))
            {
                cardToMod.AddModifier(modifier);
                cardsModded++;
            }
            it++;
        }
        for (int j = 0; j < amountToMod - cardsModded; j++) //try to add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
        {
            CardInfo cardToMod = list[UnityEngine.Random.Range(0, list.Count - 1)];
            cardToMod.AddModifier(modifier);
        }
    }
    public void UpgradeRandomCards(int amount, int mod,List<CardInfo> list=null)
    {
        int cardsModded = 0;
        int it = 0;
        if(list==null)
        {
            list=  GameHandler.Instance.GetGameState()._deck;
        }
        while (it < list.Count && cardsModded < amount)
        {
            CardInfo cardToMod = list[UnityEngine.Random.Range(0, list.Count - 1)];
            cardToMod._number+=mod;
            if(cardToMod._number<0)
            {
                cardToMod._number=0;
            }
            it++;
        }
    }

}