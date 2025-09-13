using TMPro;
using UnityEngine;

public class ShopItemContent : MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardItemPrefab;
    private int _remainingChoices;
    public void SetRewardGrid()
    {
        foreach (Item rwItem in GameHandler.Instance.GetShopItems())
        {
            GameObject rwInstance = Instantiate(_rewardItemPrefab, this.transform);
            rwInstance.GetComponent<RewardItem>().AssignItem(rwItem,rwItem.GetRarity()*5);
        }
    }
    public void RemoveAllGrid()
    {
        foreach (Transform rwItemTransform in this.transform)
        {
            Destroy(rwItemTransform.gameObject);
        }
    }
}
