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
    public List<ItemContainer> _serializableItems;
    public String _currentEncounterName;
    public int _rubles;
    public int _health;
    public int _lastHealth;
    public int _maxhealth;
    public int _day;
    public int _encounter;
    public int _restPoints;
    public int _maxrestPoints;
    public int _restRpointCost;
    public int _shopRpointCost;
    public int _gadalkaRpointCost;
    public int _handSize;
    public int _maxRewardSelection;
    public int _maxRewardChoices;
    public int _rareItemRewardDropRate;//  out of 100;
    public int _consumableDropRate;
    public int _legendaryItemInshopDropRate;
    public int _rareItemInshopDropRate;
    public bool _redCardsSameSuit;
    public bool _blackCardsSameSuit;
    public Dictionary<string, int> _itemStacks;
    public int _itemsShownInShop;
    public int _maxCardModsInShop;
    public int _discardingCardInShopCost;
    public int _startingDiscardInShopCost;
    public int _shopRerollCost;
    public bool _shopUnlocked;
    public bool _gadalkaUnlocked;
    public int _freeShopRerolls;
    public int _maxFreeShopRerolls;
    public int _startingShopRerollCost;
    public bool[] _undamagable; //0 player 1 enemy
    public int _enemyHandSize;
    public bool _loseToWin;//activates on Insider Investor.
    public bool _healingAndDamageInverted;
    public int _shopCostPerCardMod;
    public int _laikaCardInShopChance;

    public int  _opponentsDamageReduction; //used for stalwart storozhevaya and can be used for other things in the future.
    public int _defaultOpponentDamageReduction;
    public int _playerDamageReduction;
    public bool _reversePossible;
    public int _playerPoisonCounters;
    public bool _poisonCountDown;
    public bool _burnPoison;
    public Dictionary<string,int> _modifierAddedEffect;
    public List<ItemContainer> _shopItems;
    public List<CardInfo> _shopCards;
    public int _gadalkaEffectsMax;
    public List<GadalkaEffectContainer> _gadalkaBlessings;
    public List<GadalkaEffectContainer> _gadalkaCurses;
    public int _opponentCardUpgradeDefault;
    public List<int> _itemsCostPerRarity;
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
                        //_deck.Add(new CardInfo("C", 13)); //debug

                    }
                    break;
                case 1:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("S", j));
                        //_deck.Add(new CardInfo("L", 0)); //debug
                    }
                    break;
                case 2:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("D", j));
                        //_deck.Add(new CardInfo("L", 0));  //debug
                    }
                    break;
                case 3:
                    for (int j = 6; j < 15; j++)
                    {
                        _deck.Add(new CardInfo("H", j));
                        //_deck.Add(new CardInfo("L", 0));  //debug
                    }
                    break;
            }
        }
        _rubles = 0;
        _health = 100;
        _lastHealth = _health;
        _maxhealth = 100;
        _day = 0;
        _encounter = 0;
        _restPoints = 3;
        _maxrestPoints = 3;
        _restRpointCost = 1;//cost to use rest action in the rest tab
        _shopRpointCost = 2;//cost to use shop action in the rest tab
        _gadalkaRpointCost=2;//cost to use gadalka in the rest tab
        _handSize = 6;
        _items = new List<Item>();
        _serializableItems = new List<ItemContainer>();
        _redCardsSameSuit = false;
        _blackCardsSameSuit = false;
        _maxRewardSelection = 3;
        _maxRewardChoices = 1;
        _rareItemRewardDropRate = 10;
        _consumableDropRate=20;
        _legendaryItemInshopDropRate = 10;
        _rareItemInshopDropRate=30;
        _itemsShownInShop = 4;
        _maxCardModsInShop = 3;
        _shopCostPerCardMod=5;
        _itemStacks = new Dictionary<string, int>();
        _discardingCardInShopCost = 5;
        _startingDiscardInShopCost = 5;
        _shopRerollCost = 5;
        _shopUnlocked=false;
        _gadalkaUnlocked=false;
        _freeShopRerolls=0;
        _maxFreeShopRerolls=0;
        _startingShopRerollCost = 5;
        _undamagable=new bool[]{false,false};
        _opponentsDamageReduction = 0;
        _defaultOpponentDamageReduction=0;
        _playerDamageReduction=0;
        _enemyHandSize = 6;
        _loseToWin=false;
        _healingAndDamageInverted=false;
        _laikaCardInShopChance=10;
        _reversePossible=true;
        _poisonCountDown=true;
        _burnPoison=false;
        InitModDamageDic();
        _shopItems= new List<ItemContainer>();
        _shopCards = new List<CardInfo>();
        _gadalkaEffectsMax=5;
        _gadalkaBlessings=new List<GadalkaEffectContainer>();
        _gadalkaCurses=new List<GadalkaEffectContainer>();
        _opponentCardUpgradeDefault=0;
        _itemsCostPerRarity=new List<int>{10,40,60};
        _currentEncounterName="";
    }
    private void InitModDamageDic()
    {
        _modifierAddedEffect = new Dictionary<string, int>  //-1 equals infinite copies
        {
            {"Restoring", 0},
            {"Bounce", 0},
            {"Burn", 0},
            {"Parry", 0},
            {"Draw", 0},
            {"Cripple", 0},
            {"Spiky", 0},
            {"Poison",0}
        };
    }
    public void ResetActiveItems() //this is called at the end of each encounter  to allow reactivating items that can be used once per combat
    {
        foreach (Item item in _items)
        {
            item.ResetActivation();
        }
    }
    public void DeleteConsumableItems()
    {
        List<Item> itemIt= new List<Item>(_items);
        foreach (Item item in itemIt)
        {
            item.DeleteConsumable();
        }
    }
    private void addItemOrStack(Item item) 
    {
        if (_itemStacks.ContainsKey(item.GetId()))
        {
            _itemStacks[item.GetId()]++;
        }
        else 
        {
            _itemStacks.Add(item.GetId(), 1);
        }
    }
    public List<ItemContainer> SaveItems(List<Item> items) 
    {
        List<ItemContainer> toRet= new List<ItemContainer>();
        foreach (Item item in items)
        {
            toRet.Add(new ItemContainer(item.GetId(), JsonUtility.ToJson(item)));
        }
        return toRet;
    }
    public List<Item> LoadItems(List<ItemContainer> sItems) 
    {
        List<Item> toRet= new List<Item>();
        foreach (ItemContainer iCont in sItems)
        {
            // Get the base ScriptableObject (pre-loaded in Resources/Items/)
            Item item = Resources.Load<Item>($"Items/{iCont.ItemID}");
            Item runtimeItem = ScriptableObject.CreateInstance(item.GetType()) as Item;
            // Create a runtime instance and apply saved data
            JsonUtility.FromJsonOverwrite(iCont.SerializedData, runtimeItem);
            item.InitItem();
            toRet.Add(item);
            addItemOrStack(item);
        }
        OnLoad();
        return toRet;
    }
    public List<GadalkaEffectContainer> SaveGEffects(List<GadalkaEffectInfo> effects) 
    {
        List<GadalkaEffectContainer> toRet= new List<GadalkaEffectContainer>();
        foreach (GadalkaEffectInfo eff in effects)
        {
            toRet.Add(new GadalkaEffectContainer(eff.GetId(), JsonUtility.ToJson(eff)));
        }
        return toRet;
    }
    public List<GadalkaEffectInfo> LoadGEffects(List<GadalkaEffectContainer> sItems) 
    {
        List<GadalkaEffectInfo> toRet= new List<GadalkaEffectInfo>();
        foreach (GadalkaEffectContainer iCont in sItems)
        {
            // Get the base ScriptableObject (pre-loaded in Resources/Items/)
            GadalkaEffectInfo effect = Resources.Load<GadalkaEffectInfo>($"GadalkaEffects/{iCont.EffectID}");
            GadalkaEffectInfo runtimeEffect = ScriptableObject.CreateInstance(effect.GetType()) as GadalkaEffectInfo;
            // Create a runtime instance and apply saved data
            JsonUtility.FromJsonOverwrite(iCont.SerializedData, runtimeEffect);
            effect.InitEffect();
            toRet.Add(effect);
        }
        return toRet;
    }
    public void AddItem(Item item) //assumes item has been initialized with InitItem()
    {
        item.OnAquire();
        _items.Add(item);
        addItemOrStack(item);
        GameHandler.Instance.SaveState();
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
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
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
    public void OnDamageOpponent(int amount, string fromMod = "")
    {
        foreach (Item item in _items)
        {
            item.OnDamageOpponent(amount, fromMod);
        }
    }
    public void OnDamagePlayer(int amount, string fromMod = "")
    {
        foreach (Item item in _items)
        {
            item.OnDamagePlayer(amount, fromMod);
        }
    }
    public void OnEndEncounter()
    {
        foreach (Item item in _items)
        {
            item.OnEndEncounter();
        }
    }
    public void OnEncounterStart()
    {
        foreach (Item item in _items)
        {
            item.OnEncounterStart();
        }
    }
    public void OnTurnEnd(int turnState)
    {
        foreach (Item item in _items)
        {
            item.OnTurnEnd(turnState);
        }
    }
    public void OnCardAdded(CardInfo card)
    {
        foreach (Item item in _items)
        {
            item.OnCardAdded(card);
        }
    }
    public int AddToDamagePlayer(int amount, bool OnlyVisual=false) 
    {
        int total=0;
        foreach (Item item in _items)
        {
            total+=item.AddToDamagePlayer(amount);
        }
        return total;
    }
    public int AddToDamageOpponent(int amount, bool OnlyVisual=false) 
    {
        int total=0;
        foreach (Item item in _items)
        {
            total+=item.AddToDamageOpponent(amount);
        }
        return total;
    }
}
