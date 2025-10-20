using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscardOptionPanel : MonoBehaviour
{
    [SerializeField]
    private Button _disButton;
    [SerializeField]
    private Button _disExitButton;
    [SerializeField]
    private GameObject _disPanel;
    [SerializeField]
    private GameObject _disContent;
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private TextMeshProUGUI _costText;
    public void Start()
    {
        //On Click config
        _disButton.onClick.AddListener(UpdateDeckContent);
        _disExitButton.onClick.AddListener(() => _disPanel.SetActive(false));
    }

    public void UpdateDeckContent()
    {
        _disPanel.SetActive(true);

        foreach (Transform card in _disContent.transform)
        {
            Destroy(card.gameObject);
        }
        foreach (CardInfo cInfo in GameHandler.Instance.GetGameState()._deck)
        {
            GameObject cardMade = Instantiate(_cardPrefab, _disContent.transform);
            cardMade.GetComponent<Card>().MakeCard(cInfo, false); //make an undraggable card
        }
    }
    public void UpdateCostText()
    {
        _costText.text = GameHandler.Instance.GetGameState()._discardingCardInShopCost.ToString();
    }   
    
}
