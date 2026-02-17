using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public abstract class Item : ScriptableObject
{
    [SerializeField]
    protected int rarity; //0 commmon, 1 rare, 2 legendary, 3 boss
    [SerializeField]
    protected bool boss;
    protected string itemId;//serialized already in the item container
    protected Sprite Icon;
    protected bool isActive;
    protected bool persistent=false;// if true the effect of the item is something that affects the entire turn. important for animations.
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
    public abstract void OnDamageOpponent(int amount);
    public abstract void OnActivate();

    public void Activate() 
    {
        if (isActive && !_hasBeenActivated)
        {
            _hasBeenActivated = true;
            OnActivate();
        }
    }
    public void ResetActivation() 
    {
        if(isActive)
        {
            _hasBeenActivated = false;
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
    public string GetItemToolTip() 
    {
        return $"<size="+SettingsState.ToolTipFontSizeTitle+"><align=center>"+GetSpacedItemId()+"</align></size>\n" +
               $"<size="+SettingsState.ToolTipFontSizeText+"><align=left>"+toolTipDesc+"</align></size>";
    }
    private string GetSpacedItemId() 
    {
        return Regex.Replace(this.itemId,
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
    public  static Dictionary<int, string> rarityIntToWord = new Dictionary<int, string>
    {
        {0,"Common"},
        {1,"Rare"},
        {2,"Legendary"},
        {3,"Boss"},
    };
}
