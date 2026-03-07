using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton:MonoBehaviour 
{
    [SerializeField]
    private GameObject _shopPanel;
    [SerializeField]
    private Button _shopCloseButton;
    [SerializeField]
    private ShopItemContent _shopItemContent;
    [SerializeField]
    private ShopCardGrid _shopCardGrid;
    [SerializeField]
    private DiscardOptionPanel _discardOptButton;
    private bool _shopPayedFor;
    private Button _shopButton;
    [SerializeField]
    private  TextMeshProUGUI _costContent;
    [SerializeField]
    private GameObject _restPointPrefab;

    public void Start()
    {
        _shopButton = GetComponent<Button>();
        _shopPayedFor = false;
        _shopButton.onClick.AddListener(() => 
        {
            if (!_shopPayedFor)
            {
                _shopPayedFor = true;
                RemoveCost();
                if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._shopRpointCost)
                {
                    GameHandler.Instance.GetGameState()._restPoints -= GameHandler.Instance.GetGameState()._shopRpointCost;
                    GameObject.Find("RestHandler").GetComponent<RestHandler>().UpdateRestUI();
                    _shopPanel.SetActive(true);
                    _shopPanel.GetComponent<Animator>().SetTrigger("Extend");
                    _shopItemContent.SetRewardGrid();
                    _shopCardGrid.SetCardGrid();
                }
            }
            else 
            {
                _shopPanel.SetActive(true);
                _shopPanel.GetComponent<Animator>().SetTrigger("Extend");
                _discardOptButton.UpdateCostText();
            }
        });

        _shopCloseButton.onClick.AddListener(() => { ShrinkShopPanel();});
        SetRestCost();
    }
private void SetRestCost()
{
        _costContent.text=$"{StylisticClass.RestPoint}{GameHandler.Instance.GetGameState()._shopRpointCost}";
}
private void RemoveCost()
{
    _costContent.text="";
}
    private async void ShrinkShopPanel()
    {
         _shopPanel.GetComponent<Animator>().SetTrigger("Shrink");
         await UniTask.Delay(300);
         _shopPanel.SetActive(false);
    }
}
