using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        _items= new List<Item>();
        _serializableItems = new List<ItemContainer>();
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
        }
        OnLoad();
    }
    public void AddItem(Item item) //assumes item has been initialized with InitItem()
    {
        item.OnAquire();
        _items.Add(item);
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
}
