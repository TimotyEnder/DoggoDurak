using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using TMPro;
using Cysharp.Threading.Tasks;


public class Deck : MonoBehaviour
{
    [SerializeField]
    private GameObject _card;
    [SerializeField]
    private List<CardInfo> _deck;

    private TurnHandler _turnHandler;
    private Discard _discard;
    [SerializeField]
    private GameObject cardDrawParticlePrefab;
    [SerializeField]
    TextMeshProUGUI _deckSizeText;

    //drawing Queue
    private Queue<Action> _drawQueue;
    private bool _isDrawing;
   
    void Awake() 
    {
        _drawQueue= new Queue<Action>();
        _isDrawing=false;
        GameObject _turnHandlerObj= GameObject.Find("TurnHandler"); 
        if(_turnHandlerObj!=null)
        {
            _turnHandler = _turnHandlerObj.GetComponent<TurnHandler>();
        }
        GameObject _discardObj= GameObject.Find("Discard"); 
        if(_discardObj!=null)
        {
            _discard = _discardObj.GetComponent<Discard>();
        }
       
    }
    void Start()
    {
         UpdateDeckSizeText();
    }
    private void UpdateDeckSizeText()
    {
        _deckSizeText.text = _deck.Count.ToString() + "/" + GameHandler.Instance.GetGameState()._deck.Count.ToString();
    }   
    public List<CardInfo> GetDeck()
    {
        return _deck;
    }
    public void LoadDeck()
    {
        _deck = new List<CardInfo>();
        foreach (CardInfo c in GameHandler.Instance.GetGameState()._deck)
        {
            _deck.Add(c);
        }
        UpdateDeckSizeText();
    }
    public void AddCard(CardInfo card)
    {
        _deck.Add(card);
    }
    public async Task LoadDiscard()
    {
        _deck = new List<CardInfo>();
        foreach(Card c in await _discard.GetPlayerDiscard())
        {
            _deck.Add(c.GetCardInfo());
        }
    }
    private void Draw() 
    {
        // CardInfo handling
        int cardDrawIndex = UnityEngine.Random.Range(0, _deck.Count);
        if(_deck.Count>0)
        {
            CardInfo cardtoDraw = _deck[cardDrawIndex];
            GameHandler.Instance.GetCurrEncounter().OnCardDrawn(cardtoDraw);
            _deck.Remove(cardtoDraw);
            
            UpdateDeckSizeText();  

            // Card draw particle with callback
            RectTransform target = GameObject.Find("DrawToHere").GetComponent<RectTransform>();
            StartCoroutine(DrawParticleRoutine(target, () => 
            {
                // This callback runs after the coroutine completes
                OnDrawParticleComplete(cardtoDraw);
            }));
        }
    }

    private void OnDrawParticleComplete(CardInfo cardtoDraw)
    {
        // Card Visual Handling
        GameObject CardDrawn = Instantiate(_card);
        CardDrawn.GetComponent<Card>().MakeCard(cardtoDraw);
        CardDrawn.GetComponent<Card>().OnDraw();
    }
    public void DrawCardParticle(RectTransform target) //for the animation of enemy stealing cards
    {
        StartCoroutine(DrawParticleRoutine(target,() =>{}));
    }
    private IEnumerator DrawParticleRoutine(RectTransform target, Action onComplete)
    {
        GameObject particle = Instantiate(cardDrawParticlePrefab, this.transform.position, Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Canvas").transform);
        CardDrawParticle particleScript = particle.GetComponent<CardDrawParticle>();
        particleScript.SetTarget(target);
        while (particle != null)
        {
            yield return null;
        }
        onComplete?.Invoke();
    }
    public  void DrawHand()
    {
        CardHandArea cardHand= GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        int  toDraw= GameHandler.Instance.GetGameState()._handSize - cardHand.GetCardsInHand(); 
        for (int i = 0; i <toDraw; i++) 
        {
            DrawCard();
        }
    }
    private async void DrawJob()
    {
        if(_deck.Count<=0)
        {
             await LoadDiscard();
        }
        if (_deck.Count > 0)
        {
            Draw();
        }
    }
    public void DrawCard()
    {
        lock(_drawQueue)
        {
           _drawQueue.Enqueue(DrawJob);
        }
        if(!_isDrawing)
        {
            DrawQueueProcess().Forget();
        }
    }
    public async UniTask DrawQueueProcess()
    {
        _isDrawing=true;
        while(true)
        {
            Action draw=null;
            lock(_drawQueue)
            {
                if(_drawQueue.Count>0)
                {
                    draw= _drawQueue.Dequeue();
                }
                else
                {
                    _isDrawing=false;
                    break;
                }
            }
            draw?.Invoke();
            await UniTask.Delay(100);
        }
    }
}
