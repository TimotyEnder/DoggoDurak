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
    protected List<string> subTooltips= new List<string>();
    protected BlingableVisualItem _invItem;// this is to be able to make the imventory items bling when triggered. Active items are handler with onActivate and that is a different system.

    public abstract void InitItem();
    //happens when played loads a safe game. anything that needs to reapply its a affect of a default new character
    // and life total does it in it's OnLoad()
    public abstract bool OnLoad(); 
    //when picked up
    public abstract bool OnAquire();
    public abstract bool OnDefendCard(Card defendee, Card defended);
    public abstract bool OnPlayedCard(Card card);
    public abstract bool OnReverse(Card card);
    public abstract bool OnHeal(int amount);
    public abstract bool OnDamageOpponent(int amount, string fromMod = "");
    public abstract bool OnDamagePlayer(int amount, string fromMod="");
    public abstract bool OnActivate();
    public abstract bool OnEndEncounter();
    public abstract bool OnTurnEnd(int turnState);
    public abstract bool OnCardAdded(CardInfo card);
    public abstract bool OnEncounterStart();
    public abstract int AddToDamagePlayer(int amount, bool OnlyVisual=false);
    public abstract  int AddToDamageOpponent(int amount, bool OnlyVisual=false);
    public void AssignInventoryItem(BlingableVisualItem i)
    {
        this._invItem=i;
    }
    public BlingableVisualItem GetInventoryItem(){return this._invItem;}
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
    public void AddSubtoolTip(string subTtext)
    {
        this.subTooltips.Add(subTtext);
    }
    public string GetItemToolTip() 
    {
        return $"<size="+SettingsState.ToolTipFontSizeTitle+"><align=center>"+GetSpacedItemName()+"</align></size>\n<align=left>" +
               $"<size="+SettingsState.ToolTipFontSizeText+"><align=left>"+toolTipDesc+"</align></size>";
    }
    public List<SubToolTip> GetSubToolTips()
    {
        List<SubToolTip> toRet= new List<SubToolTip>();
        foreach(string sTstr in this.subTooltips)
        {
            toRet.Add(new SubToolTip($"<size={SettingsState.ToolTipFontSizeText}><align=center>{sTstr}</size></align>"));
        }
        return toRet;
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
            it++;
        }
    }
}
