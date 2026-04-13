using UnityEngine;
using UnityEngine.UI;

class ConsumablesGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardItemPrefab;
    private GameObject _grid;

    void Awake()
    {
        _grid = GetComponentInChildren<GridLayoutGroup>().gameObject;
    }

    public void SetRewardGrid()
    {
        if (GameHandler.Instance.GetCurrReward().consumables.Count > 0)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        foreach (Item rwItem in GameHandler.Instance.GetCurrReward().consumables)
        {
            GameObject rwInstance = Instantiate(_rewardItemPrefab, _grid.transform);
            rwInstance.GetComponent<RewardItem>().AssignItem(rwItem);
        }
    }
}
