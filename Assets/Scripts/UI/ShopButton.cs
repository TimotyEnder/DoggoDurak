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
        _shopPayedFor = GameHandler.Instance.GetGameState()._shopUnlocked;
        SetRestCost();
        this.gameObject.GetComponent<ToolTip>().SetToolTipText($"<size={SettingsState.ToolTipFontSizeText}><align=center>For {GameHandler.Instance.GetGameState()._shopRpointCost}{StylisticClass.RestPoint}, {StylisticClass.HighLight}purchase powerful trinkets{StylisticClass.HighLightClose} to become a better Durak player!</align></size>");
        if(_shopPayedFor){RemoveCost();}
        _shopButton.onClick.AddListener(() => 
        {
            if (!_shopPayedFor)
            {
                if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._shopRpointCost)
                {
                    _shopPayedFor = true;
                    GameHandler.Instance.GetGameState()._shopUnlocked=true;
                    RemoveCost();
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
                _shopItemContent.SetRewardGrid();
                _shopCardGrid.SetCardGrid();
                _discardOptButton.UpdateCostText();
            }
            GameHandler.Instance.SaveState();
        });

        _shopCloseButton.onClick.AddListener(() => { ShrinkShopPanel();});
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
