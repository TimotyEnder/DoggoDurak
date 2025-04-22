using UnityEngine;
using UnityEngine.UI;

public class OrderByRankButton : MonoBehaviour
{
    private Button _rankButton;
    private CardHandArea _cardHand;
    void Start()
    {
        _rankButton= this.GetComponent<Button>();
        _cardHand = GameObject.Find("CardHandArea").GetComponent<CardHandArea>();
        _rankButton.onClick.AddListener(RankButtonClick);
    }
    void RankButtonClick()
    {
        _cardHand.OrderByRank();
    }
}
