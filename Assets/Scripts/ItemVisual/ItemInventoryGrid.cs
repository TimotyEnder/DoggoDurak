using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ItemInventoryGrid:MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryItemPrefab;

    private void Start()
    {
        UpdateItemGrid();
    }

    public void UpdateItemGrid() 
    {
        HashSet<string> itemsUpdated = new HashSet<string>();
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
        foreach (Item i in GameHandler.Instance.GetGameState()._items)
        {

            if (!i.IsActive() && !itemsUpdated.Contains(i.name))
            {
                GameObject IIintance = Instantiate(inventoryItemPrefab, this.transform);
                InventoryItem IIscript = IIintance.GetComponent<InventoryItem>();
                IIscript.AssignItem(i);
                int stacks= GameHandler.Instance.GetGameState()._itemStacks[i.name];
                if (stacks > 1) 
                {
                    IIscript.SetStackNum(stacks);
                }
                itemsUpdated.Add(i.name);    
            }
        }
    }
}
