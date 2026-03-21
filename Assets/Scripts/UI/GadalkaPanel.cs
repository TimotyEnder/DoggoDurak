using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GadalkaPanel:MonoBehaviour
{
    [SerializeField]
    private GameObject _cursesPanel;
    [SerializeField]
    private GameObject _blessingsPanel;
    [SerializeField]
    private TextMeshProUGUI _pointsText;
    [SerializeField]
    private GameObject _gadalkaEffectPrefab;
    private int _points;
    [SerializeField]
    private Button _confirmButton;
    private  List<GadalkaEffectInfo> _selectedEffects;
    [SerializeField]
    private GadalkaButton _gButton;
    void  Awake()
    {
        _points=0;
        _selectedEffects= new List<GadalkaEffectInfo>();
    }
    void Start()
    {
        _confirmButton.onClick.AddListener(ConfirmButtonHandler);
    }
    private async void ConfirmButtonHandler()
    {
        if(_points>=0)
        {
            foreach(GadalkaEffectInfo gEff in _selectedEffects)
            {
                gEff.ExecuteEffect();
                gEff.GetGEffect().GetComponent<Animator>().SetTrigger("Click");
                await UniTask.Delay(300);
                Destroy(gEff.GetGEffect().gameObject);
            }
            foreach(GadalkaEffectContainer c in GameHandler.Instance.GetGameState().SaveGEffects(_selectedEffects.FindAll((c)=>c.IsBlessing())))
            {
                GameHandler.Instance.GetGameState()._gadalkaBlessings.RemoveAll((a)=>a.EffectID==c.EffectID);
            }
            foreach(GadalkaEffectContainer c in GameHandler.Instance.GetGameState().SaveGEffects(_selectedEffects.FindAll((c)=>!c.IsBlessing())))
            {
                GameHandler.Instance.GetGameState()._gadalkaCurses.RemoveAll((a)=>a.EffectID==c.EffectID);
            }
            GameHandler.Instance.SaveState();
            _selectedEffects= new List<GadalkaEffectInfo>();
            _gButton.ShrinkShopPanel();
        }
        else
        {
            _pointsText.color=Color.red;
            await UniTask.Delay(100);
            _pointsText.color=Color.white;
        }
    }
    public void SetGadalkaEffects()
    {
        foreach(RectTransform e in _blessingsPanel.transform)
        {
            Destroy(e.gameObject);
        }
         foreach(RectTransform e in _cursesPanel.transform)
        {
            Destroy(e.gameObject);
        }
        foreach(GadalkaEffectInfo gInfo in GameHandler.Instance.CompileBlessings())
        {
            GameObject gEffect= Instantiate(_gadalkaEffectPrefab,_blessingsPanel.transform);
            gEffect.GetComponent<GadalkaEffect>().MakeGEffect(gInfo,this);
        }
        foreach(GadalkaEffectInfo gInfo in GameHandler.Instance.CompileCurses())
        {
            GameObject gEffect= Instantiate(_gadalkaEffectPrefab,_cursesPanel.transform);
            gEffect.GetComponent<GadalkaEffect>().MakeGEffect(gInfo,this);
        }
    }
    public  void SelectEffect(GadalkaEffectInfo gEff)
    {
        _selectedEffects.Add(gEff);
        _points=_points+gEff.GetCost();
        UpdatePointsText();
    }
     public  void UnSelectEffect(GadalkaEffectInfo gEff)
    {
        _selectedEffects.Remove(gEff);
        _points=_points-gEff.GetCost();
        UpdatePointsText();
    }
    private void UpdatePointsText()
    {
        if(_points>0)
        {
            _pointsText.color= Color.green;
        }
        if(_points<0)
        {
            _pointsText.color= Color.red;
        }
        else
        {
            _pointsText.color= Color.white;
        }
        _pointsText.text=_points.ToString();
    }
}