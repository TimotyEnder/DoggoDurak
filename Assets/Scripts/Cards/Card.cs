
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler

{
    private CardInfo _cardInfo;
    private RectTransform _cardRect;
    private GameObject _cardHandArea;
    private RectTransform _cardHandAreaRect;
    private CardHandArea _cardHandAreaScript;
    private int _oldSiblingIndex;
    private GameObject _cardImage;
    private Canvas _canvas;
    private RectTransform _cardImageRect;
    [SerializeField]
    private bool _isInteractable;
    private int _cost;
    [SerializeField]
    private TextMeshProUGUI _costText;
    private GameObject _playArea;
    private RectTransform _playAreaRect;
    private PlayArea _playAreaScript;
    private bool _played;
    private TurnHandler _turnHandler;
    private bool _defended;
    private Card _cardDefending;
    private OpponentLogic _opponent;
    //visual modifiers
    [SerializeField]
    private GameObject _notPermissible;
    private GameObject _bounceOverlay;
    private GameObject _burnOverlay;
    private TextMeshProUGUI _burnText;
    private GameObject _crippleOverlay;
    private GameObject _drawOverlay;
    private TextMeshProUGUI _drawText;
    private GameObject _parryOverlay;
    private GameObject _restoringOverlay;
    private TextMeshProUGUI _restoringText;
    private GameObject _spikyOverlay;
    private Animator _animator;
    private bool _tryToHighlightCard=true; //this will be true to try to retrigger the on pointer logics until on pointer exit happens
    private RuleHandler _rh;
    private CanvasScaler _cScaler;
    private bool _grey=false; //make greyed out card undraggable.
    private bool _playedSelectAnim=false;
    public Vector3 _oldEuAngle;
    
    //text prefabs for card modifier effects
    [SerializeField]
    private GameObject burnTextPrefab;
    [SerializeField]
    private GameObject restoringTextPrefab;
    [SerializeField]
    private GameObject bounceTextPrefab;
    [SerializeField]
    private GameObject spikyTextPrefab;
    [SerializeField]
    private GameObject cripplingTextPrefab;
    [SerializeField]
    private GameObject parryTextPrefab;
    [SerializeField]
    private GameObject drawTextPrefab;
    private PassButton _passButton;
    void Start()
    {
    }
    void Awake()
    {
        //card hand area
        _cardHandArea = GameObject.Find("CardHandArea");
        if (_cardHandArea != null)
        {
            _cardHandAreaScript = _cardHandArea.GetComponent<CardHandArea>();
            _cardHandAreaRect = _cardHandArea.GetComponent<RectTransform>();
        }

        //RectTransform is commonly used so we init it
        _cardRect = this.GetComponent<RectTransform>();


        //sibling index
        this._oldSiblingIndex = -1;

        //canvas
        GameObject _tempcanvas = GameObject.Find("UI");
        if (_tempcanvas != null)
        {
            _canvas = _tempcanvas.GetComponent<Canvas>();
            _cScaler = _tempcanvas.GetComponent<CanvasScaler>();
        }

        //Card Image
        _cardImage = _cardRect.Find("CardImage").gameObject;
        if (_cardImage != null)
        {
            _cardImageRect = _cardImage.GetComponent<RectTransform>();
        }

        //Play Area
        _playArea = GameObject.Find("PlayArea");
        if (_playArea != null)
        {
            _playAreaRect = _playArea.GetComponent<RectTransform>();
            _playAreaScript = _playArea.GetComponent<PlayArea>();
        }

        //turn handler
        GameObject turnHandlerObj = GameObject.Find("TurnHandler");
        if (turnHandlerObj != null)
        {
            _turnHandler = turnHandlerObj.GetComponent<TurnHandler>();
        }
        //Defended
        _defended = false;
        //Opponent
        GameObject opponentObj = GameObject.Find("Opponent");
        if (opponentObj != null)
        {
            _opponent = opponentObj.GetComponent<OpponentLogic>();
        }
        _animator=this.gameObject.GetComponent<Animator>();
        _animator.applyRootMotion = false;

        GameObject rhObj= GameObject.Find("RuleHandler");
        if(rhObj!=null)
        {
            _rh=rhObj.GetComponent<RuleHandler>();
        }
        GameObject passBtnObj= GameObject.Find("PassButton");
        if(passBtnObj!=null)
        {
            _passButton= passBtnObj.GetComponent<PassButton>();
        }
    }
    public void MakeCard(CardInfo card, bool IsInteractable=true, int Cost=0)
    {
        this._cardInfo = card;
        card.AssignCard(this);
        Sprite cardSprite = Resources.Load<Sprite>("Grafics/Cards/" + _cardInfo._suit + _cardInfo._number.ToString());
        transform.Find("CardImage").gameObject.SetActive(true);
        _cardImage.GetComponent<Image>().sprite = cardSprite;
        _isInteractable = IsInteractable;
        _cost = Cost;
        if (_cost > 0)
        {
            _costText.gameObject.SetActive(true);
            _costText.text = _cost.ToString();
        }
        UpdateModifiers();
        _cardRect.localScale = Vector3.one;
        this.GetComponent<ToolTip>().SetToolTipText(_cardInfo.CompileTooltipDescription());
    }
    public void SetAnimatable(bool state)
    {
        if(_animator.enabled==false)
        {
            _animator.enabled=true; 
        }
        if(!state)
        {
          _animator.applyRootMotion = false;
          _animator.enabled=false;
        }
        else
        {
            _animator.applyRootMotion = true;
        }
    }
    public void GreyIn()
    {
        _grey=true;
        _cardImage.GetComponent<Image>().color = Color.grey;
    }
    public void GreyOut()
    {
        _grey=false;
        _cardImage.GetComponent<Image>().color = Color.white;
    }
    public void CheckPlayPermission()
    {
        if(!GameHandler.Instance.CanPlayCard(this.GetCardInfo(),0))
        {
            _notPermissible.SetActive(true);
        }
        else
        {
            _notPermissible.SetActive(false);
        }
    }
    public void Bling()
    {
        if (_animator != null)
        {
            StartCoroutine(BlingRoutine());
        }
    }
    private IEnumerator BlingRoutine()
    {
        SetAnimatable(true);
        _animator.SetTrigger("Bling");
        yield return new WaitForSeconds(0.15f);
        SetAnimatable(false);
    }
    public void Hit()
    {
        if (_animator != null)
        {
            StartCoroutine(HitRoutine());
        }
    } 
    private IEnumerator HitRoutine()
    {
        SetAnimatable(true);
        _animator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.20f);
        SetAnimatable(false);
    }  
    public void SpawnModifierEffect(CardModifierContainer c)
    {
        GameObject instancedText = null;
        
        if(_rh.CanEffectsSpawn()){
            switch (c.ModType)
            {
                case "Restoring":
                    Debug.Log("Restoring");
                    instancedText = Instantiate(restoringTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Bounce":
                    Debug.Log("Bounce");
                    instancedText = Instantiate(bounceTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Burn":
                    Debug.Log("Burn");
                    instancedText = Instantiate(burnTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Parry":
                    Debug.Log("Parry");
                    instancedText = Instantiate(parryTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Draw":
                    Debug.Log("Draw");
                    instancedText = Instantiate(drawTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Cripple":
                    Debug.Log("Cripple");
                    instancedText = Instantiate(cripplingTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break;
                case "Spiky":
                    Debug.Log("Spiky");
                    instancedText = Instantiate(spikyTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                    break; 
            }
        }
        if (instancedText != null)
        {
            instancedText.GetComponent<ModifierText>().Init(this.GetCardInfo(),_canvas);
        }

    }
    public float GetAnimSpeed() 
    {
        return _animator.speed;
    }
    public void UpdateModifiers() 
    {
        //cardModifiers
        _restoringOverlay = transform.Find("CardImage/RestoringMod").gameObject;
        _bounceOverlay = transform.Find("CardImage/BounceMod").gameObject;
        _burnOverlay = transform.Find("CardImage/BurnMod").gameObject;
        _crippleOverlay = transform.Find("CardImage/CrippleMod").gameObject;
        _drawOverlay = transform.Find("CardImage/DrawMod").gameObject;
        _drawText = transform.Find("CardImage/DrawText").gameObject.GetComponent<TextMeshProUGUI>();
        _parryOverlay = transform.Find("CardImage/ParryMod").gameObject;
        _spikyOverlay = transform.Find("CardImage/SpikyMod").gameObject;

        _restoringOverlay.SetActive(false);
        _bounceOverlay.SetActive(false);
        _burnOverlay.SetActive(false);
        _parryOverlay.SetActive(false);
        _drawOverlay.SetActive(false);
        _crippleOverlay.SetActive(false);
        _spikyOverlay.SetActive(false);
        _drawText.gameObject.SetActive(false);

        _cardInfo.UpdateModifiers();

        foreach (KeyValuePair<string,int> c in _cardInfo._modifierStacks) 
        {
            switch(c.Key) 
            {
                case "Restoring":
                    _restoringOverlay.SetActive(true);
                    break;
                case "Bounce":
                    _bounceOverlay.SetActive(true);
                    break;
                case "Burn":
                    _burnOverlay.SetActive(true);
                    break;
                case "Parry":
                    _parryOverlay.SetActive(true);
                    break;
                case "Draw":
                    _drawOverlay.SetActive(true);
                    _drawText.gameObject.SetActive(true);
                    _drawText.text = c.Value.ToString();
                    break;
                case "Cripple":
                    _crippleOverlay.SetActive(true);
                    break;
                case "Spiky":
                    _spikyOverlay.SetActive(true);
                    break;
            }
        }
    }
    public void OnDraw()
    {
        _played = false;
        _cardRect.SetParent(_cardHandAreaRect);
        _cardRect.localScale = Vector3.one;
        _cardRect.SetSiblingIndex(0);
        _cardHandAreaScript.AttachCard();
        _cardHandAreaScript.AddToCards(this);
        _cardHandAreaScript.RealignCardsInHand();
    }
     public void OnDraw(Vector2 screenPoint)
    {
        _played = false;
        _cardRect.SetParent(_cardHandAreaRect);
        _cardRect.localScale = Vector3.one;
        _cardRect.SetSiblingIndex(0);
        _cardHandAreaScript.AttachCard();
        _cardHandAreaScript.AddToCards(this,screenPoint);
        _cardHandAreaScript.RealignCardsInHand();
    }
    public void OnPlay(Vector2 screenPoint)
    {
        int cardDefendingIndex = _playAreaScript.GetCardDefending(screenPoint);
        CardInfo cardToDefend = null;
        if (cardDefendingIndex!=-1) 
        {
            cardToDefend= _playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>().GetCardInfo();
        }
        //playing cards  as it is your turn
        if (_turnHandler.GetTurnState() == 0 && _playAreaScript.CanAttackWithCard(this.GetCardInfo()))
        {
            PlayCard();
            if(_cardHandAreaScript.GetCardsInHand()==0)
            {
                _passButton.SetJiggle(false);
                StartCoroutine(_opponent.EnemyPlay());
            }
            _passButton.SetJiggle(true);
        }
        //Defending, not your turn
        else if (_turnHandler.GetTurnState() != 0 && cardDefendingIndex != -1 && _playAreaScript.CardCanDefendCard(this.GetCardInfo(), cardToDefend))
        {
            DefendCard(_playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>());
            if(_cardHandAreaScript.GetCardsInHand()==0)
            {
                _passButton.SetJiggle(false);
                StartCoroutine(_opponent.EnemyPlay());
            }
            _passButton.SetJiggle(true);
        }
        //reverse
        else if (_playAreaScript.CanReverseWithCard(this._cardInfo) && _turnHandler.GetTurnState() != 0) 
        {
            PlayCard();
            _cardInfo.OnReverse(this);
            if (!_cardInfo._opponentCard)
            {
                GameHandler.Instance.GetGameState().OnReverse(this);
            }
            else
            {
                GameHandler.Instance.GetCurrEncounter().OnReverse(this);
            }
            _turnHandler.Reverse();
            StartCoroutine(_opponent.EnemyPlay());
        }
        else
        {
            OnDraw();
        }
    }
    public void PlayCard() 
    {
        _cardRect.SetParent(_playAreaRect.transform.Find("PlayedCards"));
        _cardImageRect.localScale = Vector3.one;
        _cardRect.localScale = Vector3.one;
        _playAreaScript.AddtoPlayedCards(this);
        _playAreaScript.AttachCard();
        _played = true;
        _cardInfo.OnPlayedCard(this);
        if (!_cardInfo._opponentCard)
        {
            GameHandler.Instance.GetGameState().OnPlayedCard(this);
        }
        else
        {
            GameHandler.Instance.GetCurrEncounter().OnPlayedCard(this);
        }
    }
    public void DefendCard(Card card) 
    {
        _cardRect.SetParent(_playAreaRect.transform.Find("DefendedCards"));
        _cardRect.SetAsFirstSibling();
        _cardImageRect.localScale = Vector3.one;
        _cardRect.localScale = Vector3.one;
        _cardRect.anchoredPosition = card.GetDefendPosition();//hehe
        card.Defend(this);
        _playAreaScript.AddtoDefendedWithCards(this);
        _played = true;
        _cardInfo.OnDefendCard(this, card);
        if (!_cardInfo._opponentCard)
        {
            GameHandler.Instance.GetGameState().OnDefendCard(this, card);
        }
        else
        {
            GameHandler.Instance.GetCurrEncounter().OnDefendCard(this, card);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _tryToHighlightCard = true;
        _oldEuAngle=_cardRect.eulerAngles;
        StartCoroutine(CheckTopPointerUntilExit(eventData));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _tryToHighlightCard = false;
        StopCoroutine(CheckTopPointerUntilExit(eventData)); // Stop the checking coroutine
        SetAnimatable(false);
        _playedSelectAnim=false;
        _cardRect.eulerAngles=Vector3.zero;
        if(_cardHandAreaScript!=null)
        {
            _cardHandAreaScript.RealignCardsInHand();
        }
        if (_oldSiblingIndex != -1 && _isInteractable)
        {
            _cardRect.SetSiblingIndex(_oldSiblingIndex);
        }
        _cardImageRect.localScale = Vector3.one;
    }
    private IEnumerator CheckTopPointerUntilExit(PointerEventData ped)
    {
        while (_tryToHighlightCard)
        {
            if (IsTopPointer(ped))
            {
                if(_isInteractable){
                    _oldSiblingIndex = _cardRect.GetSiblingIndex();
                    _cardRect.SetAsLastSibling();
                }
                _cardImageRect.localScale = Vector3.one * 1.3f;
                if(!_playedSelectAnim)
                {
                    _playedSelectAnim=true;
                    SetAnimatable(true);
                    _animator.SetTrigger("Select");
                    yield return new WaitForSeconds(0.05f);
                }
            }
            
            // Wait for next frame before checking again
            yield return null;
        }
    }
    private bool IsTopPointer(PointerEventData ped)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Card>() != null)
            {
                return result.gameObject == this.gameObject;
            }
        }
        
        return false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_played || _grey ||!_isInteractable) { return; } //return early in this method fails the drag.
        GetComponent<ToolTip>().SetTooltipActiveState(false);
        _cardRect.SetParent(_canvas.gameObject.GetComponent<RectTransform>());
    }
    public void OnDrag(PointerEventData eventData)
    {
         if (_played || _grey ||!_isInteractable) { return; }
        _cardRect.eulerAngles = Vector3.zero;
        _cardRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (_played && !_opponent.IsEnemyPlaying()|| _grey ||!_isInteractable) { return; }
        GetComponent<ToolTip>().SetTooltipActiveState(true);
        _cardHandAreaScript.RemoveFromCards(this);
        _cardHandAreaScript.DettachCard();
        if (RectTransformUtility.RectangleContainsScreenPoint(_playAreaRect, eventData.position) && GameHandler.Instance.CanPlayCard(this.GetCardInfo(), (GetCardInfo()._opponentCard?1:0)))
        {
            OnPlay(eventData.position);
        }
        else
        {
            OnDraw(eventData.position);
        }
    }
    public Vector2 GetDefendPosition()
    {
        return new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x, this.GetComponent<RectTransform>().anchoredPosition.y - (this.GetComponent<RectTransform>().rect.height*0.5f));
    }
    public CardInfo GetCardInfo()
    {
        return this._cardInfo;
    }
    public void Defend(Card defendedWith) 
    {
        _defended = true;  
        _cardDefending = defendedWith;
        _cardInfo.OnBeingDefended(defendedWith);
    }
    public Card GetCardDefending() 
    {
        return _cardDefending;
    }
    public bool IsDefended() 
    {
        return _defended;   
    }
    public void MoveTowardsToDiscard()
    {
        _isInteractable = false; 
        Vector2 target = GameObject.Find("Discard").GetComponent<DiscardPilePositions>().GetDiscardPileCardPosition();
        UnityEngine.Quaternion rotation = GameObject.Find("Discard").GetComponent<DiscardPilePositions>().GetRandomRotation();  
        GetComponent<ToolTip>().SetTooltipActiveState(false);
        _cardRect.SetParent(_canvas.gameObject.GetComponent<RectTransform>()); 
        StartCoroutine(MoveTowardsCoroutine(target, rotation));
    }
    private IEnumerator MoveTowardsCoroutine(Vector2 target, UnityEngine.Quaternion? rotation=null)
    {
        float speed = 2000f;
        while (Vector2.Distance(_cardRect.anchoredPosition, target) > 0.01f)
        {
            float distance = Vector2.Distance(_cardRect.anchoredPosition, target);
            float step = speed * Time.deltaTime;
            
            // Prevent overshoot by limiting step to remaining distance
            if (step > distance)
            {
                step = distance;
            }
            
            _cardRect.anchoredPosition = Vector2.MoveTowards(_cardRect.anchoredPosition, target, step);
            yield return null;
        }
        _cardRect.SetAsFirstSibling();
        if (rotation != null)
        {
            _cardRect.rotation = (UnityEngine.Quaternion)rotation;
        }
    }
    public void OnPointerClick(PointerEventData eventData) //this is to handle buyable cards
    {

        if (!_isInteractable && _cost > 0 && GameHandler.Instance.GetGameState()._rubles >= _cost)
        {
            GameHandler.Instance.GetGameState()._rubles -= _cost;
            GameObject.Find("RubleText").GetComponent<RubleText>().UpdateRubleAmount();
            GameHandler.Instance.AddCardToDeck(this.GetCardInfo());
            GetComponent<ToolTip>().SetTooltipActiveState(false);
            Destroy(this.gameObject);
        }
        else
        {
            GameObject disOpt = GameObject.Find("DiscardButton");
            if (!_isInteractable && disOpt != null)
            {
                DiscardOptionPanel disOptScript = disOpt.GetComponent<DiscardOptionPanel>();
                if(GameHandler.Instance.GetGameState()._rubles>=GameHandler.Instance.GetGameState()._discardingCardInShopCost)
                {
                    GameHandler.Instance.GetGameState()._rubles -= GameHandler.Instance.GetGameState()._discardingCardInShopCost;
                    GameObject.Find("RubleText").GetComponent<RubleText>().UpdateRubleAmount();
                    Debug.Log("Card Removed");
                    GameHandler.Instance.GetGameState()._deck.Remove(GetCardInfo());
                    GetComponent<ToolTip>().SetTooltipActiveState(false);
                    GameHandler.Instance.GetGameState()._discardingCardInShopCost++;
                    disOptScript.UpdateCostText();
                    disOptScript.UpdateDeckContent();
                    Destroy(this.gameObject);
                }

            }
        }
    }
}

