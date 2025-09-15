using System.Runtime.CompilerServices;
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
    private bool _shopPayedFor;
    private Button _shopButton;

    public void Start()
    {
        _shopButton = GetComponent<Button>();
        _shopPayedFor = false;
        _shopButton.onClick.AddListener(() => 
        {
            if (!_shopPayedFor)
            {
                _shopPayedFor = true;
                if (GameHandler.Instance.GetGameState()._restPoints >= GameHandler.Instance.GetGameState()._shopRpointCost)
                {
                    GameHandler.Instance.GetGameState()._restPoints -= GameHandler.Instance.GetGameState()._shopRpointCost;
                    GameObject.Find("RestHandler").GetComponent<RestHandler>().UpdateRestUI();
                    _shopPanel.SetActive(true);
                    _shopItemContent.SetRewardGrid();
                }
            }
            else 
            {
                _shopPanel.SetActive(true);
            }
        });

        _shopCloseButton.onClick.AddListener(() => { _shopPanel.SetActive(false);});
    }
}
