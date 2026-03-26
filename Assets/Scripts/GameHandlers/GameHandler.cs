using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;
    [SerializeField]
    private GameState _state;
    private Lazy<SaveManager> _saveManager = new Lazy<SaveManager>(); //elegant fix to start init issue
    private Lazy<RewardManager> _rewardManager = new Lazy<RewardManager>();
    private EncounterManager _encounterManager;
    private GadalkaEffectManager _gadalkaEffectManager;
    private CharacterManager _characterManager;
    private Encounter _currentEncounter;
    private Character _currentCharacter;
    [SerializeField]
    private Reward _currentReward;
    private  DebuffManager  _debuffManager;
    public static GameHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameHandler>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameHandler).Name);
                    _instance = singleton.AddComponent<GameHandler>();
                    DontDestroyOnLoad(singleton);
                }

            }
            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        _characterManager= new CharacterManager();
        _debuffManager = new DebuffManager();
    }
    public bool HasSave()
    {
        return _saveManager.Value.Load() != null;
    }
    public void NewGame(string characerChoice="")
    {
        
        _state = new GameState();
        _currentCharacter= _characterManager.GetCharacterInfo().here();
        _state._rubles=_currentCharacter.GetStartRub();
        foreach(Item i in _currentCharacter.LoadItems())
        {
            _state.AddItem(i);
        }
        _saveManager.Value.Save(_state);
        _encounterManager = new EncounterManager();
        _gadalkaEffectManager =  new GadalkaEffectManager();
        //debug
        foreach (CardInfo c in _state._deck)
        {
            //c.MakeLaika();
            //c.AddModifier("Burn",10);
            //c.AddModifier("Restoring");
            //c.AddModifier("Bounce");
            //c.AddModifier("Parry");
            //c.AddModifier("Draw");
            //c.AddModifier("Cripple");
            //c.AddModifier("Spiky",100);
            //c.AddModifier("Poison");
        }
        //debug
        //Item debugItem3 = ScriptableObject.CreateInstance<TheIronCurtain>();
        //debugItem3.InitItem();
        //_state.AddItem(debugItem3);
        //_state._rubles=100; //debug
        //_currentEncounter= new DebugEncounter();
        //_currentEncounter.InitiateEncounter();
        Next();
    }
    public void SaveState()
    {
        _saveManager.Value.Save(_state);
    }
    public void Continue() //enters only if hasSave returns true but if somehow trying to acess without pressing the button
    {
        if (HasSave())
        {
            _state = _saveManager.Value.Load();
            Next(true); //this doesnt increment encounter so you stay on the same one.
        }
    }
    public void Next(bool FromContinue=false) // will be called after an encounter or rest is finished and will handle what should happen next
    {
        ResetEncounterGamestateAttributes();
        if(_encounterManager==null)
        {
            _encounterManager = new EncounterManager();
        }
        _saveManager.Value.Save(_state);
        if(!FromContinue){_state._encounter++;}
        //_state._encounter = 11; //debug insta boss
        //_state._encounter = 4; //debug insta shop
        _state.ResetActiveItems();
        if (_state._encounter % 4 == 0 && _state._encounter > 0) //every three encounters you have a rest
        {
            SceneManager.LoadScene(2);
        }
        else if(_state._encounter==11) 
        {
            _currentEncounter = _encounterManager.RandomBossEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        else if (_state._encounter < 12)
        {
            _currentEncounter = _encounterManager.RandomEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        else
        {
            _state._day++;
            _state._encounter = 1;
            _currentEncounter = _encounterManager.RandomEncounter(_state._day);
            SceneManager.LoadScene(1);
        }
        _state.OnEncounterStart();
    }
    public GameState GetGameState()
    {
        return _state;
    }
    public Encounter GetCurrEncounter()
    {
        return _currentEncounter;
    }
    public Reward GetCurrReward()
    {
        return _currentReward;
    }
    public void GenerateReward()
    {
        if(_state._encounter==11)
        {
            _currentReward = _rewardManager.Value.GenerateBossReward();
        }
        else
        {
            _currentReward = _rewardManager.Value.GenerateReward();
        }
        _currentReward.consumables = _rewardManager.Value.RollConsumableChance();
    }
    public List<Item> GetShopItems() 
    {
        List<Item> itemsToReturn = new List<Item>();
        if(_state._shopItems.Count<=0)
        {
            int legendaryItemsInShop = 0;
            int rareItemsInShop=0;
            int commonItemsInShop=0;
            for (int i = 0; i < GameHandler.Instance.GetGameState()._itemsShownInShop; i++)
            {
                int roll = UnityEngine.Random.Range(1, 100);
                if (roll <= GameHandler.Instance.GetGameState()._legendaryItemInshopDropRate)
                {
                    legendaryItemsInShop++;
                }
                else if(roll >= (100-GameHandler.Instance.GetGameState()._rareItemInshopDropRate))
                {
                    rareItemsInShop++;
                }
                else
                {
                    commonItemsInShop++;
                }
            }
            itemsToReturn.AddRange(_rewardManager.Value.ShopReward(2, legendaryItemsInShop));
            itemsToReturn.AddRange(_rewardManager.Value.ShopReward(1,rareItemsInShop));
            itemsToReturn.AddRange(_rewardManager.Value.ShopReward(0,commonItemsInShop));
            _state._shopItems=_state.SaveItems(itemsToReturn);
            SaveState();
        }
        else
        {
            itemsToReturn= _state.LoadItems(_state._shopItems);
        }
        return itemsToReturn;   
    }
    public void SetHealth(int health)
    {
        _state._lastHealth = _state._health;
        _state._health = health;
        if (_state._health > _state._maxhealth)
        {
            _state._health = _state._maxhealth;
        }
        if (GameObject.Find("PlayerLifeTotal") != null && GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().SetHealth(health);
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().UpdateHealthUI();
        }
    }
    public void SetMaxHealth(int amount)
    {
        _state._maxhealth+=amount;
        GameObject maxHpText=GameObject.Find("MaxPlayerHealthText");
        if(maxHpText!=null)
        {
            maxHpText.GetComponent<MaxPlayerHealthText>().Increase(amount);
        }
        if(GameHandler.Instance.GetGameState()._health>GameHandler.Instance.GetGameState()._maxhealth)
        {
            GameHandler.Instance.SetHealth(GameHandler.Instance.GetGameState()._maxhealth);
        }
    }
    //Heal From effect should be true for heals comes from item/card effects to not create an infinite chain of healing!
    public async void HealPlayer(int amount, bool fromEffect = false, int times=1,string fromMod = "") //any healing effects should be handled by this
    {
        if (GameObject.Find("PlayerLifeTotal") != null && GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
        {
            if(!_state._healingAndDamageInverted)
                {
                    for(int i=0;i<times; i++)
                    {
                        GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Heal(amount);
                        await UniTask.Delay(100);
                    }
                }
                else
                {
                    for(int i=0;i<times; i++)
                    {
                        GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Damage(amount);
                        await GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState(); //player might be dead mid-turn
                        await UniTask.Delay(100);
                    }
                }
        }
        if (!fromEffect)
        {
            DelayedPlayerOnHealAsync(amount).Forget();
        }
    }
    private async UniTaskVoid DelayedPlayerOnHealAsync(int amount,string fromMod="")
    {
        // Wait for next frame to ensure UI animations complete
        await UniTask.Delay(200);
        
         _state.OnHeal(amount);
    }
    public void HealOpponent(int amount,bool fromEffect=false) //any healing effects should be handled by this
    {
        if (GameObject.Find("OpponentsLifeTotal") != null && GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().Heal(amount);
        }
        //fromEffect should be here just as a placehoolder if we ever add OnHealOpponent()
    }
    public async void DamageOpponent(int amount, bool fromEffect = false, string fromMod = "", int times=1,bool checkMatchEnd=true) //any effects damaging the enemy should go through this
    {
        int damageCalc;
        if(!fromEffect)
        {
            damageCalc=_currentEncounter.ModifyDamageOpponent(amount) + _state.AddToDamageOpponent(amount);
        }
        else
        {
            damageCalc=amount;
        }
        if(_state._undamagable[1])
        {
            if (GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
            {
                GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().ShowNoDamage();
            }
        }
        else
        {
            if (GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
            {
               for(int i=0;i<times;i++)
                {
                    GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().Damage(damageCalc-_state._opponentsDamageReduction,fromMod);
                    if(checkMatchEnd)
                    {
                          await GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState();//opponent might be dead mid-turn
                    }
                    await UniTask.Delay(100);
                }
            }
            if (!fromEffect)
            {
                DelayedOnDamageOpponentAsync(damageCalc-_state._opponentsDamageReduction,fromMod).Forget();
            }
        }
    }
    private async UniTaskVoid DelayedOnDamageOpponentAsync(int amount,string fromMod)
    {
        // Wait for next frame to ensure UI animations complete
        await UniTask.Delay(200);
        
        _state.OnDamageOpponent(amount,fromMod);
        _currentEncounter.OnDamageOpponent(amount,fromMod);
    }
    public void PoisonOpponent(int amount)
    {
        _currentEncounter.AddPoisonCounter(amount);
        if(GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("OpponentsLifeTotal").GetComponent<LifeTotal>().UpdatePoisonCounters(true);
        }
    }
    public async void DamagePlayer(int amount,bool fromEffect = false, string fromMod = "", int times =1, bool checkMatchEnd=true) //any effects damaging the player should go through this
    {
        int damageCalc=_currentEncounter.ModifyDamagePlayer(amount)+ _state.AddToDamagePlayer(amount);
        if(_state._undamagable[0])
        {
            if (GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
            {
                GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().ShowNoDamage();
            }
        }
        else
        {
            if (GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
            {
               
               if(!_state._healingAndDamageInverted || fromMod=="InsiderTrader")
                {
                    for(int i=0;i<times; i++)
                    {
                        GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Damage(damageCalc-GameHandler.Instance.GetGameState()._playerDamageReduction,fromMod);
                       if(checkMatchEnd)
                        {
                             await GameObject.Find("RuleHandler").GetComponent<RuleHandler>().CheckGameState(); //player might be dead mid-turn
                        }
                        await UniTask.Delay(100);
                    }
                }
                else
                {
                    for(int i=0;i<times; i++)
                    {
                        GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().Heal(damageCalc-GameHandler.Instance.GetGameState()._playerDamageReduction);
                        await UniTask.Delay(100);
                    }
                }
            }
            if (!fromEffect)
            {
               _state.OnDamagePlayer(amount,fromMod);
               DelayedOnDamagePlayerAsync(damageCalc,fromMod).Forget();
            }
        }
    }
    private async UniTaskVoid DelayedOnDamagePlayerAsync(int amount,string fromMod)
    {
        // Wait for next frame to ensure UI animations complete
        await UniTask.NextFrame();
        _currentEncounter.OnDamagePlayer(amount,fromMod);
    }
    public void PoisonPlayer(int amount)
    {
        _state._playerPoisonCounters+=amount;
        if(GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>() != null)
        {
            GameObject.Find("PlayerLifeTotal").GetComponent<LifeTotal>().UpdatePoisonCounters(false);
        }
    }
    public void PlayerPoisonHandler()
    {
        if(_state._playerPoisonCounters>0)
        {
            DamagePlayer(_state._playerPoisonCounters,true,fromMod:"Poison");
            PoisonPlayer(-1);
        }
    }
    public void Draw(int amount)
    {
        GameObject Deck= GameObject.Find("Deck");
        if(Deck!=null)
        {
            Deck deckSc=Deck.GetComponent<Deck>();
            for (int i = 0; i < amount; i++)
            {
               deckSc.DrawCard();
            }
        }
    }
    public void OpponentDraw(int amount)
    {
        GameObject Opp= GameObject.Find("Opponent");
        if(Opp!=null)
        {
            OpponentLogic oppSc=Opp.GetComponent<OpponentLogic>();
            for (int i = 0; i < amount; i++)
            {
               oppSc.DrawCard();
            }
        }
    }
    public void OpponentDiscard(int amount)
    {
        if (GameObject.Find("Opponent").GetComponent<OpponentLogic>() != null)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject.Find("Opponent").GetComponent<OpponentLogic>().Discard();
            }
        }
    }
    public void PlayerDiscard(int index, int amount=1)
    {
        Debug.Log("Discarding card at index: " + index+" amount: "+amount);
        GameObject CardHandArea= GameObject.Find("CardHandArea");
        if (CardHandArea != null)
        {
            CardHandArea cardHScript = CardHandArea.GetComponent<CardHandArea>();
            if (cardHScript != null)
            {
                _currentEncounter.OnHandCardDiscarded(cardHScript.GetCards()[index].GetCardInfo());
                cardHScript.Discard(index,amount);
            }
        }
    }
    public int GetPlayerCardsInHand()
    {
        GameObject CardHandArea = GameObject.Find("CardHandArea");
        if (CardHandArea != null)
        {
            CardHandArea cardHScript = CardHandArea.GetComponent<CardHandArea>();
            if (cardHScript != null)
            {
                return cardHScript.GetCards().Count;
            }
        }
        return 0;
    }
    public void ReAddItems(List<Item> items)
    {
        _rewardManager.Value.ReAddItems(items);
    }
    public void SortDeck()
    {
        _state._deck.Sort((a, b) => a._suitNumber == b._suitNumber ? 
            a._number.CompareTo(b._number) : 
            a._suitNumber.CompareTo(b._suitNumber));
    }
    public void AddCardToDeck(CardInfo card)
    {
        _state._deck.Add(card);
        SaveState();
        SortDeck();
        GameObject playerDeck= GameObject.Find("Deck");
        if(playerDeck!=null)
        {
            playerDeck.GetComponent<Deck>().AddCard(card);
        }
        _state.OnCardAdded(card);
    }
    public void AddCurrencyCalculator(CurrencyCalculator cc) 
    {
        _rewardManager.Value.AddCurrencyCalculator(cc);
    }
    public string GetCurrencyExplanationText() 
    {
        return _rewardManager.Value.GetCurrencyExplanationText();
    }
    //0 player 1 opponent.
    public bool IsCardnotDebuffed(CardInfo card, int target) 
    {
        return _debuffManager.CanPlayCard(card, target);
    } 
    public void  ResetDebuffs() 
    {
         _debuffManager.ResetPermissions();
         UIupdateDebuffs();
    }  
    public void SetDebuffs(string[]perms, bool forPlayer,bool forEnemy,bool[] AllEven=null,bool[] AllOdd=null)
    {
        _debuffManager.SetPermissions(perms,forPlayer,forEnemy,AllEven,AllOdd);
        UIupdateDebuffs();
    }
    public void EncounterSetDebuffs()
    {
        _currentEncounter.SetDebuffs();
    }
    public void UIupdateDebuffs()
    {
        GameObject cardHandArea= GameObject.Find("CardHandArea");
        if (cardHandArea != null)
        {
            cardHandArea.GetComponent<CardHandArea>().CheckPlayPermissionHand();
        }
    }
    public void ResetPersistentItems()
    {
        foreach (Transform item in GameObject.Find("ActiveItemInventory").transform)
        {
            item.gameObject.GetComponent<ActiveItem>().ResetAnim();
        }
        _state._undamagable=new bool[]{false,false};
    }
    public int GetUnblockedCards()
    {
        GameObject playArea= GameObject.Find("PlayArea");
        if(playArea!=null)
        {
            return playArea.GetComponent<PlayArea>().UnblockedCardsAmount();
        }
        else
        {
            return -1;
        }
    }
    public void ShakeRule(int index) 
    {
        GameObject ruleHandler= GameObject.Find("RulesUIBox");
        Debug.Log("Shaking rule at index: " + index);
        if(ruleHandler!=null)
        {
            ruleHandler.GetComponentInChildren<RuleBoxUI>().ShakeRule(index);
        }
    }
    public void UpdateRules() 
    {
        GameObject ruleHandler= GameObject.Find("RulesUIBox");
        if(ruleHandler!=null)
        {
            ruleHandler.GetComponentInChildren<RuleBoxUI>().UpdateRules();
        }
    }
    public void ResetEncounterGamestateAttributes() 
    {
        _state._opponentsDamageReduction = _state._defaultOpponentDamageReduction;
        _state._enemyHandSize = 6;
        _state._loseToWin=false;
        _state._healingAndDamageInverted=false;
        _state._playerPoisonCounters=0;
        ResetDebuffs();
    }
    public void AddToOpponentCurrentDeck(CardInfo card)
    {
        GameObject opponentDeck= GameObject.Find("Opponent");
        if(opponentDeck!=null)
        {
            opponentDeck.GetComponent<OpponentLogic>().AddToDeck(card);
        }
    }
    public async void EnemyStealingCardParticles(int amount)
    {
        GameObject target= GameObject.Find("OpponentsLifeTotal");
        GameObject deck= GameObject.Find("Deck");
        if(deck!=null)
        {
            RectTransform targetRect=target.GetComponent<RectTransform>();
            for(int i=0;i<amount;i++)
            {
                deck.GetComponent<Deck>().DrawCardParticle(targetRect);
                await UniTask.Delay(200);
            }
        }
    }
    public void UpdateMoney(int amount)
    {
        _state._rubles+=amount;
        GameObject rubleObj= GameObject.Find("RubleText");
        if(rubleObj!=null)
        {
            rubleObj.GetComponent<RubleText>().UpdateRubleAmount();
        }
    }
    public int PlayerOddCardsInHand()
    {
        GameObject cardHandArea= GameObject.Find("CardHandArea");
        if (cardHandArea != null)
        {
            return cardHandArea.GetComponent<CardHandArea>().OddCards();
        }
        return -1;
    }
    public int PlayerEvenCardsInHand()
    {
        GameObject cardHandArea= GameObject.Find("CardHandArea");
        if (cardHandArea != null)
        {
            return cardHandArea.GetComponent<CardHandArea>().EvenCards();
        }
        return -1;
    }
    public CardInfo GetCardInHand(int index)
    {
        GameObject cardHandArea= GameObject.Find("CardHandArea");
        if (cardHandArea != null)
        {
            return cardHandArea.GetComponent<CardHandArea>().GetCards()[index].GetCardInfo();
        }
        return null;
    }
    public void ClearTemporaryModifiers()
    {
        foreach(CardInfo c in _state._deck)
        {
            
            if(c.ClearTemporaryModifiers()&&c._card!=null)
            {
                c._card.MakeCard(c);
                c._card.Bling();
            }
        }
    }
    public List<GadalkaEffectInfo> CompileBlessings()
    {
        if(GameHandler.Instance.GetGameState()._gadalkaBlessings.Count>0)
        {
            return _state.LoadGEffects(_state._gadalkaBlessings);
        }
        else
        {
            List<GadalkaEffectInfo> toRet=_gadalkaEffectManager.BlessingCompile(_state._gadalkaEffectsMax);
            _state._gadalkaBlessings=_state.SaveGEffects(toRet);  
            SaveState();
            return toRet;  
        }
    }
    public List<GadalkaEffectInfo> CompileCurses()
    {
        if(GameHandler.Instance.GetGameState()._gadalkaCurses.Count>0)
        {
            return _state.LoadGEffects(_state._gadalkaCurses);
        }
        else
        {
            List<GadalkaEffectInfo> toRet=_gadalkaEffectManager.CursesCompile(_state._gadalkaEffectsMax);
            _state._gadalkaCurses=_state.SaveGEffects(toRet);  
            SaveState();
            return toRet;  
        }
    }
    public LoopList<Character> GetCharacterInfo()
    {
        return _characterManager.GetCharacterInfo();
    }
}
