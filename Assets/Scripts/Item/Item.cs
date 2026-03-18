using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
[Serializable]
public abstract class Item : ScriptableObject
{
    [SerializeField]
    protected int rarity; //0 commmon, 1 rare, 2 legendary, 3 boss
    [SerializeField]
    protected bool boss;
    protected string itemId;//serialized already in the item container
    protected string itemName;
    protected Sprite Icon;
    protected bool isActive;
    protected bool persistent=false;// if true the effect of the item is something that affects the entire turn. important for animations.
    protected bool consumable=false;
    protected bool _hasBeenActivated=false;
    protected string toolTipDesc;

    public abstract void InitItem();
    //happens when played loads a safe game. anything that needs to reapply its a affect of a default new character
    // and life total does it in it's OnLoad()
    public abstract void OnLoad(); 
    //when picked up
    public abstract void OnAquire();
    public abstract void OnDefendCard(Card defendee, Card defended);
    public abstract void OnPlayedCard(Card card);
    public abstract void OnReverse(Card card);
    public abstract void OnHeal(int amount);
    public abstract void OnDamageOpponent(int amount, string fromMod = "");
    public abstract void OnDamagePlayer(int amount, string fromMod="");
    public abstract void OnActivate();
    public abstract void OnEndEncounter();
    public abstract void OnTurnEnd(int turnState);
    public abstract void OnCardAdded(CardInfo card);
    public abstract void OnEncounterStart();

    public bool Activate() 
    {
        if (isActive && !_hasBeenActivated)
        {
            _hasBeenActivated = true;
            OnActivate();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool hasBeenActivated()
    {
        return _hasBeenActivated;
    }
    public void ResetActivation() 
    {
        if(isActive)
        {
            _hasBeenActivated = false;
        }
    }
    public void DeleteConsumable()
    {
        if(consumable && _hasBeenActivated)
        {
            GameHandler.Instance.GetGameState().RemoveItem(this);
        }
    }
    public void LoadIcon(string icon) 
    {
        this.Icon= Resources.Load<Sprite>("ItemIcons/"+icon);
    }
    public bool IsBoss() 
    {
        return boss;
    }
    public int GetRarity() 
    {
        return rarity;
    }
    public string GetId() 
    {
        return itemId;
    }
    public string GetName()
    {
        return itemName;
    }
    public string GetItemToolTip() 
    {
        return $"<size="+SettingsState.ToolTipFontSizeTitle+"><align=center>"+GetSpacedItemName()+"</align></size>\n" +
               $"<size="+SettingsState.ToolTipFontSizeText+"><align=left>"+toolTipDesc+"</align></size>";
    }
    private string GetSpacedItemName() 
    {
        return Regex.Replace(this.itemName,
           "([a-z])([A-Z])|([A-Z])([A-Z][a-z])",
           "$1$3 $2$4");
    }
    public Sprite GetIcon() 
    {
        return Icon;
    }
    public bool IsActive() 
    {
        return isActive;
    }
    public bool  IsPersistent() 
    {
        return persistent;
    }   
    public bool IsConsumable()
    {
        return consumable;
    }
    public  static Dictionary<int, string> rarityIntToWord = new Dictionary<int, string>
    {
        {0,"Common"},
        {1,"Rare"},
        {2,"Legendary"},
        {3,"Boss"},
    };
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
        for (int j = 0; j < amountToMod - cardsModded; j++) //try top add modifiers even if one instance of them is on every card. Sigleton modifiers handled internally by addModifier()
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
            it++;
        }
    }
}
