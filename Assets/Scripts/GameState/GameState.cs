using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[Serializable]
public class GameState
{
    public List<CardInfo> _deck;
    [NonSerialized]
    public List<Item> _items;
    [SerializeField]
    private List<ItemContainer> _serializableItems;
    public int _rubles;
    public int _health;
    public int _maxhealth;
    public int _day;
    public int _encounter;
    public int _restPoints;
    public int _maxrestPoints;
    public int _restRpointCost;
    public int _handSize;
    public int _maxRewardSelection;
    public int _maxRewardChoices;
    public int _rareItemRewardDropRate;//  out of 100;
    public bool _redCardsSameSuit;
    public bool _blackCardsSameSuit;
    public Dictionary<string, int> _itemStacks;
    public GameState() 
    {
        _deck = new List<CardInfo>(); //standart durak deck initialization
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("C", j));

                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("S", j));
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("D", j));
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("H", j));
                    }
                    break;
            }
        }
        _rubles = 0;
        _health = 100;
        _maxhealth = 100;
        _day = 0;
        _encounter = 0;
        _restPoints = 3;
        _maxrestPoints = 3;
        _restRpointCost = 1; //cost to use rest action in the rest tab
        _handSize = 6;
        _items= new List<Item>();
        _serializableItems = new List<ItemContainer>();
        _redCardsSameSuit = false;
        _blackCardsSameSuit= false;
        _maxRewardSelection = 3;
        _maxRewardChoices = 1;
        _rareItemRewardDropRate = 10;
        _itemStacks = new Dictionary<string, int>();
    }
    private void addItemStack(Item item) 
    {
        if (_itemStacks.ContainsKey(item.name))
        {
            _itemStacks[item.name]++;
        }
        else 
        {
            _itemStacks.Add(item.name, 1);
        }
    }
    public void SaveItems() 
    {
        _serializableItems.Clear();
        foreach (Item item in _items)
        {
            _serializableItems.Add(new ItemContainer(item.GetId(), JsonUtility.ToJson(item)));
        }
    }
    public void LoadItems() 
    {
        _items.Clear();
        foreach (ItemContainer iCont in _serializableItems)
        {
            // Get the base ScriptableObject (pre-loaded in Resources/Items/)
            Item item = Resources.Load<Item>($"Items/{iCont.ItemID}");
            Item runtimeItem = ScriptableObject.CreateInstance(item.GetType()) as Item;
            // Create a runtime instance and apply saved data
            JsonUtility.FromJsonOverwrite(iCont.SerializedData, runtimeItem);
            item.InitItem();
            _items.Add(item);
            addItemStack(item);
        }
        OnLoad();
    }
    public void AddItem(Item item) //assumes item has been initialized with InitItem()
    {
        item.OnAquire();
        _items.Add(item);
        addItemStack(item);
        GameObject itemInventory = GameObject.Find("ItemInventory");
        GameObject activeItemInventory = GameObject.Find("ActiveItemInventory");
        if (activeItemInventory != null) 
        {
            ActiveItemInventoryGrid aIscript = activeItemInventory.GetComponent<ActiveItemInventoryGrid>();
            if (aIscript != null)
            {
                aIscript.UpdateItemGrid();
            }
        }
        if (itemInventory != null)
        {
            ItemInventoryGrid Iscript = itemInventory.GetComponent<ItemInventoryGrid>();
            if (Iscript != null) 
            {
                Iscript.UpdateItemGrid();
            }
        }
    }
    //happens when played loads a safe game. anything that needs to reapply its a affect of a default new character
    // and life total does it in it's OnLoad()
    public void OnLoad() 
    {
        foreach (Item item in _items)
        {
            item.OnLoad();
        }
    }
    public void OnDefendCard(Card defendee, Card defended) 
    {
        foreach (Item item in _items)
        {
            item.OnDefendCard(defendee, defended);
        }
    }
    public void OnPlayedCard(Card card) 
    {
        foreach (Item item in _items)
        {
            item.OnPlayedCard(card);
        }
    }
    public  void OnReverse(Card card) 
    {
        foreach (Item item in _items)
        {
            item.OnReverse(card);
        }
    }
    public void OnHeal(int amount) 
    {
        foreach (Item item in _items)
        {
            item.OnHeal(amount);
        }
    }
    public void OnDamageOpponent(int amount)
    {
        foreach (Item item in _items)
        {
            item.OnDamageOpponent(amount);
        }
    }
}
