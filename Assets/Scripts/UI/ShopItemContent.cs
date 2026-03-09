using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemContent : MonoBehaviour
{
    [SerializeField]
    private GameObject _rewardItemPrefab;
    private Canvas _canvas;
    void Awake()
    {
        _canvas= GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    public void SetRewardGrid()
    {
        foreach (Item rwItem in GameHandler.Instance.GetShopItems())
        {
            GameObject rwInstance = Instantiate(_rewardItemPrefab);
            rwInstance.GetComponent<RectTransform>().localScale= Vector3.one*1.7f*_canvas.scaleFactor;
            rwInstance.transform.SetParent(this.transform);
            rwInstance.GetComponent<RewardItem>().AssignItem(rwItem,(rwItem.GetRarity()+1)*50);
        }
    }
    public void RemoveAllGrid()
    {
         List<Item> toReturnItems = new List<Item>();
        foreach (Transform rwItemTransform in this.transform)
        {
            Item toReturn = rwItemTransform.GetComponent<RewardItem>().GetAssignedItem();
            toReturnItems.Add(toReturn);
        }
        GameHandler.Instance.ReAddItems(toReturnItems);
        foreach (Transform rwItemTransform in this.transform)
        {
            Destroy(rwItemTransform.gameObject);
        }
    }
    public void ReRoll()
    {
        RemoveAllGrid();
        SetRewardGrid();
    }
}
