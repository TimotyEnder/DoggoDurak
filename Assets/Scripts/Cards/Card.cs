
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using NUnit.Framework.Internal.Commands;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
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
    //text prefabs for card modifier effects
    [SerializeField]
    private GameObject burnTextPrefab;
    [SerializeField]
    private GameObject restoringTextPrefab;

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
        this.GetComponent<ToolTip>().SetToolTipText(_cardInfo.CompileTooltipDescription());
    }
    public void Bling()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("Bling");
        }
    }
    public void SpawnModifierEffect(CardModifierContainer c)
    {
        GameObject instancedText = null;
        Debug.Log(c.ModType);
        switch (c.ModType)
        {
            case "Restoring":
                Debug.Log("Restoring");
                instancedText = Instantiate(restoringTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                break;
            case "Bounce":
                break;
            case "Burn":
                Debug.Log("Burn");
                instancedText = Instantiate(burnTextPrefab, this.transform.position, this.transform.rotation, _canvas.transform);
                break;
            case "Parry":
                break;
            case "Draw":
                break;
            case "Cripple":
                break;
            case "Spiky":
                break;
        }
        if (instancedText != null)
        {
            Debug.Log("Spawned");
            Vector2 randDirMod = GetSemiCircleNormVect();
            Rigidbody2D rbInst = instancedText.GetComponent<Rigidbody2D>();;
            rbInst.linearVelocity = randDirMod * (_canvas.pixelRect.width*0.20f);
            StartCoroutine(ModTextEffectCoroutine(instancedText));
        }

    }
    private Vector2 GetSemiCircleNormVect()
    {
        float startAngle=40f;
        float endAngle=140f;
        Vector2 toRet=Random.insideUnitCircle.normalized;
         // Get its angle and magnitude
        float originalAngle = Mathf.Atan2(toRet.y, toRet.x);
        float magnitude = toRet.magnitude;
    
        // Remap angle to our semicircle segment
        float normalizedAngle = (originalAngle + Mathf.PI) / (2f * Mathf.PI); // Convert to 0-1
        float targetAngle = Mathf.Lerp(startAngle * Mathf.Deg2Rad, endAngle * Mathf.Deg2Rad, normalizedAngle);
        toRet=new Vector2(Mathf.Cos(targetAngle), Mathf.Sin(targetAngle)).normalized;
        return toRet;
    }
    public IEnumerator ModTextEffectCoroutine(GameObject textEff)
    {
        yield return new WaitForSeconds(0.5f);
        textEff.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(textEff, 1f);
    }
    public float GetAnimSpeed() 
    {
        return _animator.speed;
    }
    public void UpdateModifiers() 
    {
        //cardModifiers
        _restoringOverlay = transform.Find("CardImage/RestoringMod").gameObject;
        _restoringText = _restoringOverlay.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        _bounceOverlay = transform.Find("CardImage/BounceMod").gameObject;
        _burnOverlay = transform.Find("CardImage/BurnMod").gameObject;
        _burnText = _burnOverlay.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        _crippleOverlay = transform.Find("CardImage/CrippleMod").gameObject;
        _drawOverlay = transform.Find("CardImage/DrawMod").gameObject;
        _drawText = _drawOverlay.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        _parryOverlay = transform.Find("CardImage/ParryMod").gameObject;
        _spikyOverlay = transform.Find("CardImage/SpikyMod").gameObject;

        _restoringOverlay.SetActive(false);
        _bounceOverlay.SetActive(false);
        _burnOverlay.SetActive(false);
        _parryOverlay.SetActive(false);
        _drawOverlay.SetActive(false);
        _crippleOverlay.SetActive(false);
        _spikyOverlay.SetActive(false);

        _cardInfo.UpdateModifiers();

        foreach (KeyValuePair<string,int> c in _cardInfo._modifierStacks) 
        {
            switch(c.Key) 
            {
                case "Restoring":
                    _restoringOverlay.SetActive(true);
                    _restoringText.text = "+";
                    break;
                case "Bounce":
                    _bounceOverlay.SetActive(true);
                    break;
                case "Burn":
                    _burnOverlay.SetActive(true);
                    _burnText.text = c.Value.ToString();
                    break;
                case "Parry":
                    _parryOverlay.SetActive(true);
                    break;
                case "Draw":
                    _drawOverlay.SetActive(true);
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
            StartCoroutine(_opponent.EnemyPlay());
        }
        //Defending, not your turn
        else if (_turnHandler.GetTurnState() != 0 && cardDefendingIndex != -1 && _playAreaScript.CardCanDefendCard(this.GetCardInfo(), cardToDefend))
        {
            DefendCard(_playAreaRect.Find("PlayedCards").GetChild(cardDefendingIndex).gameObject.GetComponent<Card>());
            StartCoroutine(_opponent.EnemyPlay());
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
        _cardRect.localScale = Vector3.one * 0.9f;
        _cardImageRect.localScale = Vector3.one * 0.9f;
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
        _cardRect.localScale = Vector3.one * 0.9f;
        _cardImageRect.localScale = Vector3.one * 0.9f;
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
        if (TopPointer(eventData) && _isInteractable)
        {
            _oldSiblingIndex = _cardRect.GetSiblingIndex();
            _cardRect.SetAsLastSibling();
            _cardImageRect.localScale = Vector3.one * 1.3f;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_oldSiblingIndex != -1 && _isInteractable)
        {
            _cardRect.SetSiblingIndex(_oldSiblingIndex);
        }
        _cardImageRect.localScale = Vector3.one;
    }
    private bool TopPointer(PointerEventData ped)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Card>() != null)
            {
                if (result.gameObject == this.gameObject)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_isInteractable)
        {
            GetComponent<ToolTip>().SetTooltipActiveState(false);
            if (_played) { return; }
            _cardRect.SetParent(_canvas.gameObject.GetComponent<RectTransform>());
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_played) { return; }
        _cardRect.eulerAngles = Vector3.zero;
        _cardRect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<ToolTip>().SetTooltipActiveState(true);
        if (_played) { return; }
        _cardHandAreaScript.RemoveFromCards(this);
        _cardHandAreaScript.DettachCard();
        if (RectTransformUtility.RectangleContainsScreenPoint(_playAreaRect, eventData.position))
        {
            OnPlay(eventData.position);
        }
        else
        {
            OnDraw();
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
            if (disOpt != null)
            {
                DiscardOptionPanel disOptScript = disOpt.GetComponent<DiscardOptionPanel>();
                if(GameHandler.Instance.GetGameState()._rubles>=GameHandler.Instance.GetGameState()._discardingCardInShopCost)
                {
                    GameHandler.Instance.GetGameState()._rubles -= GameHandler.Instance.GetGameState()._discardingCardInShopCost;
                    GameObject.Find("RubleText").GetComponent<RubleText>().UpdateRubleAmount();
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

