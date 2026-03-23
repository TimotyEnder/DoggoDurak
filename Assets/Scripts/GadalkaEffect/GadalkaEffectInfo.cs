using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
[CreateAssetMenu(fileName = "GadalkaEffect", menuName = "Scriptable Objects/GadalkaEffect")]
[Serializable]
public abstract class GadalkaEffectInfo:ScriptableObject
{
    protected string descriptionText;
    protected bool blessing;
    protected int cost;
    protected string effectId;
    protected GadalkaEffect gEffect;
    public abstract void InitEffect();
    public abstract void ExecuteEffect();
    public string GetId()
    {
        return this.effectId;
    }
    public string GetDescription()
    {
        return this.descriptionText;
    }
    public bool IsBlessing()
    {
        return this.blessing;
    }
    public int GetCost()
    {
        return this.cost;
    }
    public void AssignGEffect(GadalkaEffect gEffect)
    {
        this.gEffect= gEffect;
    }
    public GadalkaEffect GetGEffect()
    {
        return this.gEffect;
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
            if(modifier=="Laika" && !cardToMod.IsLaika())
            {
                cardToMod.MakeLaika();
                cardsModded++;
            }
            else if (modifier!="Laika" && !cardToMod._modifierStacks.ContainsKey(modifier))
            {
                cardToMod.AddModifier(modifier);
                cardsModded++;
            }
            it++;
        }
        for (int j = 0; j < amountToMod - cardsModded; j++) //try to add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
        {
            CardInfo cardToMod = list[UnityEngine.Random.Range(0, list.Count - 1)];
            if(modifier=="Laika")
            {
                cardToMod.MakeLaika();
            }
            else if(modifier!="Laika")
            {
                cardToMod.AddModifier(modifier);
            }
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