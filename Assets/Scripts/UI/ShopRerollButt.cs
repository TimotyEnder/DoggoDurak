using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopRerollButt : MonoBehaviour
{
    [SerializeField]
    private ShopItemContent _shopItemContent;
    [SerializeField]
    private ShopCardGrid _shopCardGrid;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private Button _button;

    public void Start()
    {
        _button.onClick.AddListener(OnRerollButtonClick);
        UpdateCostText();
    }
    private void OnRerollButtonClick()
    {
        if (GameHandler.Instance.GetGameState()._shopRerollCost <= GameHandler.Instance.GetGameState()._rubles  || GameHandler.Instance.GetGameState()._freeShopRerolls>0)
        {
            if(GameHandler.Instance.GetGameState()._freeShopRerolls<=0)
            {
                GameHandler.Instance.UpdateMoney(-GameHandler.Instance.GetGameState()._shopRerollCost);
                GameHandler.Instance.GetGameState()._shopRerollCost += 5;
            }
            else
            {
                GameHandler.Instance.GetGameState()._freeShopRerolls--;
            }
            _shopItemContent.ReRoll();
            _shopCardGrid.ReRoll();
            UpdateCostText();
        }
    }
    private void UpdateCostText()
    {
        if(GameHandler.Instance.GetGameState()._freeShopRerolls<=0)
        {
            _costText.text =  GameHandler.Instance.GetGameState()._shopRerollCost.ToString()+_costText.text[_costText.text.Length-1];
        }
        else
        {
            _costText.text=GameHandler.Instance.GetGameState()._freeShopRerolls.ToString()+"x0"+_costText.text[_costText.text.Length-1].ToString();
        }
    }

}
