using TMPro;
using UnityEngine;

public class RubleText : MonoBehaviour
{
    private  TextMeshProUGUI _rubleText;
    void Start()
    {
        _rubleText = GetComponent<TextMeshProUGUI>();
        UpdateRubleAmount();
    }
    public void UpdateRubleAmount() 
    {
        _rubleText.text = GameHandler.Instance.GetGameState()._rubles.ToString();
    }
}
