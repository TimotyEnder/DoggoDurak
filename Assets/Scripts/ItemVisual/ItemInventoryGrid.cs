using UnityEngine;

public class ItemInventoryGrid:MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryItemPrefab;

    private void Start()
    {
        UpdateItemGrid();
    }
    public void Update()
    {
        
    }
    public void UpdateItemGrid() 
    {
        foreach (Item i in GameHandler.Instance.GetGameState()._items)
        {
            if (!i.IsActive())
            {
                GameObject IIintance = Instantiate(inventoryItemPrefab, this.transform);
                InventoryItem IIscript = IIintance.GetComponent<InventoryItem>();
                IIscript.AssignItem(i);
            }
        }
    }
}
