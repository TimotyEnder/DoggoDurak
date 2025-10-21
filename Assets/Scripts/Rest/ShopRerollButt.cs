using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopRerollButt : MonoBehaviour
{
    [SerializeField]
    private ShopItemContent _shopItemContent;
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
        if (GameHandler.Instance.GetGameState()._shopRerollCost <= GameHandler.Instance.GetGameState()._rubles)
        {
            GameHandler.Instance.GetGameState()._rubles -= GameHandler.Instance.GetGameState()._shopRerollCost;
            GameHandler.Instance.GetGameState()._shopRerollCost += 5;
            _shopItemContent.ReRoll();
            UpdateCostText();
            GameObject.Find("RubleText").GetComponent<RubleText>().UpdateRubleAmount();
        }
    }
    private void UpdateCostText()
    {
        _costText.text =  GameHandler.Instance.GetGameState()._shopRerollCost.ToString();
    }

}
