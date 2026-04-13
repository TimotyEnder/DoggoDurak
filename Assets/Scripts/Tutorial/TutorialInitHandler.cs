using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TutorialInitHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardPrefab;

    //Atack info
    [SerializeField]
    private CardHandArea _chAttackInfo;

    [SerializeField]
    private PlayArea _paAttackInfo;

    [SerializeField]
    private TurnHandler _thAttackInfo;

    [SerializeField]
    private TurnStateToggle _tsTAttackInfo;

    //Turmp info

    [SerializeField]
    private CardHandArea _chTrumpInfo;

    [SerializeField]
    private PlayArea _paTrumpInfo;

    [SerializeField]
    private TurnHandler _thTrumpInfo;

    [SerializeField]
    private TurnStateToggle _tsTTrumpInfo;

    //defend info

    [SerializeField]
    private CardHandArea _chDefendkInfo;

    [SerializeField]
    private PlayArea _paDefendInfo;

    [SerializeField]
    private TurnHandler _thDefendInfo;

    [SerializeField]
    private TurnStateToggle _tsTDefendInfo;

    //reverse info

    [SerializeField]
    private CardHandArea _chReverseInfo;

    [SerializeField]
    private PlayArea _paReverseInfo;

    [SerializeField]
    private TurnHandler _thReverseInfo;

    [SerializeField]
    private TurnStateToggle _tsTReverseInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _thAttackInfo.SetPlayArea(_paAttackInfo);
        _thAttackInfo.SetTurnStateToggle(_tsTAttackInfo);
        _thDefendInfo.SetPlayArea(_paDefendInfo);
        _thDefendInfo.SetTurnStateToggle(_tsTDefendInfo);
        _thReverseInfo.SetPlayArea(_paReverseInfo);
        _thReverseInfo.SetTurnStateToggle(_tsTReverseInfo);
        _thTrumpInfo.SetPlayArea(_paTrumpInfo);
        _thTrumpInfo.SetTurnStateToggle(_tsTTrumpInfo);
    }

    void Start()
    {
        //_tsTReverseInfo.Toggle();
        //_tsTDefendInfo.Toggle();
        //_tsTTrumpInfo.Toggle();
        //seting up card hands
        List<CardInfo> atkInfoList = new List<CardInfo>()
        {
            new CardInfo("C", 6),
            new CardInfo("D", 8),
            new CardInfo("H", 8),
        };
        List<CardInfo> trumpInfoList = new List<CardInfo>
        {
            new CardInfo("C", 6),
            new CardInfo("D", 10),
            new CardInfo("H", 6),
        };
        List<CardInfo> defendInfoList = new List<CardInfo>
        {
            new CardInfo("C", 12),
            new CardInfo("S", 12),
            new CardInfo("H", 12),
        };
        List<CardInfo> reverseInfoList = new List<CardInfo>
        {
            new CardInfo("C", 10),
            new CardInfo("D", 10),
            new CardInfo("H", 10),
        };
        foreach (CardInfo c in atkInfoList)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetCardHandArea(_chAttackInfo);
            cardSc.SetPlayArea(_paAttackInfo);
            cardSc.SetTurnHandler(_thAttackInfo);
            cardSc.OnDraw();
        }
        foreach (CardInfo c in trumpInfoList)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetCardHandArea(_chTrumpInfo);
            cardSc.SetPlayArea(_paTrumpInfo);
            cardSc.SetTurnHandler(_thTrumpInfo);
            cardSc.OnDraw();
        }
        foreach (CardInfo c in defendInfoList)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetCardHandArea(_chDefendkInfo);
            cardSc.SetPlayArea(_paDefendInfo);
            cardSc.SetTurnHandler(_thDefendInfo);
            cardSc.OnDraw();
        }
        foreach (CardInfo c in reverseInfoList)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetCardHandArea(_chReverseInfo);
            cardSc.SetPlayArea(_paReverseInfo);
            cardSc.SetTurnHandler(_thReverseInfo);
            cardSc.OnDraw();
        }

        //setting up playareas with the necessary hands
        List<CardInfo> trumpInfoListPlay = new List<CardInfo> { new CardInfo("H", 12, true) };
        List<CardInfo> defendInfoListPlay = new List<CardInfo>
        {
            new CardInfo("C", 8, true),
            new CardInfo("H", 8, true),
            new CardInfo("S", 8, true),
        };
        List<CardInfo> reverseInfoListPlay = new List<CardInfo> { new CardInfo("C", 10, true) };
        foreach (CardInfo c in trumpInfoListPlay)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetPlayArea(_paTrumpInfo);
            cardSc.SetTurnHandler(_thTrumpInfo);
            cardSc.PlayCard();
        }
        foreach (CardInfo c in defendInfoListPlay)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetPlayArea(_paDefendInfo);
            cardSc.SetTurnHandler(_thDefendInfo);
            cardSc.PlayCard();
        }
        foreach (CardInfo c in reverseInfoListPlay)
        {
            GameObject CardDrawn = Instantiate(_cardPrefab);
            Card cardSc = CardDrawn.GetComponent<Card>();
            cardSc.MakeCard(c);
            cardSc.SetPlayArea(_paReverseInfo);
            cardSc.SetTurnHandler(_thReverseInfo);
            cardSc.PlayCard();
        }
    }

    //Update is called once per frame
    void Update() { }
}
