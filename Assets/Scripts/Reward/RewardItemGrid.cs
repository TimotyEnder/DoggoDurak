using TMPro;
using UnityEngine;

public class RewardItemGrid:MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardItemPrefab;
    private int _remainingChoices;
    private TextMeshProUGUI _chooseText;
    public void SetRewardGrid() 
    {
        _chooseText = GameObject.Find("ChooseText").GetComponent<TextMeshProUGUI>();
        foreach (Item rwItem in GameHandler.Instance.GetCurrReward().items) 
        {
            GameObject rwInstance = Instantiate(_rewardItemPrefab, this.transform);
            rwInstance.GetComponent<RewardItem>().AssignItem(rwItem);
        }
        _remainingChoices=GameHandler.Instance.GetGameState()._maxRewardChoices;
        UpdateChooceText();
    }
    public void RemoveAllGrid() 
    {
        foreach (Transform rwItemTransform in this.transform) 
        {
            Destroy(rwItemTransform.gameObject);
        }
    }
    public void ChoiceHappened() 
    {
        _remainingChoices--;
        UpdateChooceText();
        if (_remainingChoices == 0) 
        {
            RemoveAllGrid();
        }
    }
    public void UpdateChooceText() 
    {
        _chooseText.text=_remainingChoices.ToString()+"/"+GameHandler.Instance.GetGameState()._maxRewardChoices.ToString();
    }
}
