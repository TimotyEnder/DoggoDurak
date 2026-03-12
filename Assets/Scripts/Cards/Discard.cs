using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Discard : MonoBehaviour
{
    List<Card> _playerCards;
    List<Card> _opponentCards;
    [SerializeField]
    private Button _discardButton;
    [SerializeField]
    private Button _discardExitButton;
    [SerializeField]
    private GameObject _discardPanel;
    [SerializeField]
    private GameObject _playerDiscardContent;
    [SerializeField]
    private GameObject _opponentDiscardContent;
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private GameObject _cardParticlePrefab;
    [SerializeField]
    private RectTransform _returnCardsHerePlayer;
    [SerializeField]
    private RectTransform _returnCardsHereOpponent;
    public void Start()
    {
        _opponentCards = new List<Card>();
        _playerCards = new List<Card>();
    }
    public void AddCard(Card card) 
    {
        if (card.GetCardInfo()._opponentCard)
        {
            _opponentCards.Add(card);
        }
        else 
        {
            _playerCards.Add(card);
        }
    }
    public void WipeDiscard()
    {  
        foreach (Card c in _playerCards)
        {
            Destroy(c.gameObject);
        }
    }   
    public async  Task<List<Card>> GetOpponentDiscard() 
    {
        List<Card> returnList;
        if(_opponentCards!=null)
        { 
             returnList= new List<Card>(_opponentCards);
        }
        else
        {
            returnList= new List<Card>();
        }
        List<Task> tasks= new List<Task>();
        int calcDelay= 1000/_opponentCards.Count;
        foreach(Card c in _opponentCards)
        {
            tasks.Add(ReturnCardToDeckVisual(c,_returnCardsHereOpponent));
            await UniTask.Delay(calcDelay);
        }
        await Task.WhenAll(tasks);
        _opponentCards=new List<Card>();
        return returnList;
    }
    public async  Task<List<Card>> GetPlayerDiscard()
    {
        // Create a new list with the same elements (shallow copy)
        List<Card> returnList;
        if(_playerCards!=null)
        { 
             returnList= new List<Card>(_playerCards);
        }
        else
        {
            returnList= new List<Card>();
        }
        List<Task> tasks= new List<Task>();
        int calcDelay= 1000/_playerCards.Count;
        foreach(Card c in _playerCards)
        {
            tasks.Add(ReturnCardToDeckVisual(c,_returnCardsHerePlayer));
            await UniTask.Delay(calcDelay);
        }
        await Task.WhenAll(tasks);
        _playerCards=new List<Card>();
        return returnList;
    }
    private async Task ReturnCardToDeckVisual(Card c,RectTransform target)
    {
        Destroy(c.gameObject);
        GameObject particle = Instantiate(_cardParticlePrefab, this.transform.position, Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Canvas").transform);
        CardDrawParticle particleScript = particle.GetComponent<CardDrawParticle>();
        particleScript.SetTarget(target);
        particleScript.SetSpeedAndAccel(2000,10000f);
        while (particle != null)
        {
            await UniTask.NextFrame();
        }
    }
    public void UpdateDiscardContent() 
    {
        _discardPanel.SetActive(true);

        foreach (Transform card in _playerDiscardContent.transform) 
        {
            Destroy(card.gameObject);
        }
        foreach (Card card in _playerCards) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_playerDiscardContent.transform);
           cardMade.GetComponent<Card>().MakeCard(card.GetCardInfo(), false); //make an undraggable card
        }
        foreach (Card card in _opponentCards) 
        {
           GameObject cardMade= Instantiate(_cardPrefab,_opponentDiscardContent.transform);
           cardMade.GetComponent<Card>().MakeCard(card.GetCardInfo(), false); //make an undraggable card
        }
    }
}
