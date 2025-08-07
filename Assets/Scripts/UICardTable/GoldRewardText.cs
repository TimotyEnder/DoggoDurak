using TMPro;
using UnityEngine;

public class GoldRewardText : MonoBehaviour
{
    private TextMeshProUGUI _goldText;
    void Start()
    {
        _goldText= GetComponent<TextMeshProUGUI>();
        UpdateGoldRewardText();
    }
    public void UpdateGoldRewardText() 
    {
        _goldText.text=GameHandler.Instance.GetCurrReward().rubleReward.ToString();
    }
}
