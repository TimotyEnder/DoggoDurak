using UnityEngine;

public class ActiveItemInventoryGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject activeInventoryItemPrefab;
    private void Start()
    {
        UpdateItemGrid();
    }
    public void UpdateItemGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child);
        }
        foreach (Item i in GameHandler.Instance.GetGameState()._items)
        {
            if (i.IsActive())
            {
                GameObject IIintance = Instantiate(activeInventoryItemPrefab, this.transform);
                ActiveItem IIscript = IIintance.GetComponent<ActiveItem>();
                IIscript.AssignItem(i);
            }
        }
    }
}
