using UnityEngine;
using UnityEngine.UI;

public class OrderBySuitButton : MonoBehaviour
{
    private Button _suitButton;
    private CardHandArea _cardHand;
    void Start()
    {
        _suitButton= this.GetComponent<Button>();
        _cardHand= GameObject.Find("CardHandArea").GetComponent<CardHandArea>();  
        _suitButton.onClick.AddListener(SuitButtonClick);
    }
    void SuitButtonClick() 
    {
        _cardHand.OrderBySuit();
    }
}
