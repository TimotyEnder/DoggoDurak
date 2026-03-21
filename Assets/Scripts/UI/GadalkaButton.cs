using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GadalkaButton:MonoBehaviour 
{
    [SerializeField]
    private GameObject _gadalkaPanel;
    [SerializeField]
    private Button _gCloseButton;
    private bool _gadalkaPayedFor;
    private Button _gadalkaButton;
    [SerializeField]
    private  TextMeshProUGUI _costContent;
    [SerializeField]
    private GadalkaPanel _gadalkaPanelSc;

    public void Start()
    {
        _gadalkaButton = GetComponent<Button>();
        _gadalkaPayedFor = GameHandler.Instance.GetGameState()._gadalkaUnlocked;
        SetRestCost();
        if(_gadalkaPayedFor){RemoveCost();}
        _gadalkaButton.onClick.AddListener(() => 
        {
            if (!_gadalkaPayedFor)
            {

                if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._gadalkaRpointCost)
                {
                    _gadalkaPayedFor = true;
                    GameHandler.Instance.GetGameState()._gadalkaUnlocked=true;
                    RemoveCost();
                    GameHandler.Instance.GetGameState()._restPoints -= GameHandler.Instance.GetGameState()._gadalkaRpointCost;
                    GameObject.Find("RestHandler").GetComponent<RestHandler>().UpdateRestUI();
                    _gadalkaPanel.SetActive(true);
                    _gadalkaPanel.GetComponent<Animator>().SetTrigger("Extend");
                }
            }
            else 
            {
                _gadalkaPanel.SetActive(true);
                _gadalkaPanel.GetComponent<Animator>().SetTrigger("Extend");
            }
            _gadalkaPanelSc.SetGadalkaEffects();
            GameHandler.Instance.SaveState();
        });

        _gCloseButton.onClick.AddListener(() => { ShrinkShopPanel();});
    }
private void SetRestCost()
{
        _costContent.text=$"{StylisticClass.RestPoint}{GameHandler.Instance.GetGameState()._gadalkaRpointCost}";
}
private void RemoveCost()
{
    _costContent.text="";
}
public async void ShrinkShopPanel()
{
        _gadalkaPanel.GetComponent<Animator>().SetTrigger("Shrink");
        await UniTask.Delay(500);
        _gadalkaPanel.SetActive(false);
}
}
