using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItemUI _itemPrefab;

    [SerializeField]
    private RectTransform _contentPanel;

    List<InventoryItemUI> listUIItems = new List<InventoryItemUI>();

    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++) 
        {
            InventoryItemUI uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(_contentPanel);
            listUIItems.Add(uiItem); // creates the items inside the inventory
        }
    }
    public void Show()
    {
        gameObject.SetActive(true); //activates the inventory
    }
    public void Hide() 
    { 
        gameObject.SetActive(false); //hides the inventory
    }
}
