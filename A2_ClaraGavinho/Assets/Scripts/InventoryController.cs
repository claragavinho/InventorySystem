using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryUI _inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    public event Action<int> OnDescriptionRequested;

    public void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }

    private void PrepareUI()
    {
        _inventoryUI.InitializeInventoryUI(inventoryData.Size);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_inventoryUI.isActiveAndEnabled == false) 
            {
                _inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    _inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity); //identifies the item's ID number, the image and quantity
                }
            }
            else 
            { 
                _inventoryUI.Hide();
            }
        }    
    }
}
