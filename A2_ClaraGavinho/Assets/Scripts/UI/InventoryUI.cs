using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItemUI _itemPrefab;

    [SerializeField]
    private InvDescriptionUI _itemDescription;

    [SerializeField]
    private RectTransform _contentPanel;

    List<InventoryItemUI> listUIItems = new List<InventoryItemUI>();

    InventoryItemUI uI;

    public event Action<int> OnDescriptionRequested;

    public event Action<InventoryUI> OnItemClicked;
    //, OnItemUsed, OnItemRemoved, OnItemSelected;

    private void Awake()
    {
        Hide();
        _itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++) 
        {
            InventoryItemUI uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(_contentPanel);
            listUIItems.Add(uiItem); // creates the items inside the inventory
        }
    }

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if(listUIItems.Count > itemIndex)
        {
            listUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }
    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        _itemDescription.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listUIItems[itemIndex].Select();
    }

    private void HandleItemClicked()
    {
        int index = listUIItems.IndexOf(uI);
        if (index == -1)
            return;
        OnItemClicked?.Invoke(this);
    }

    private void HandleItemSelection()
    {
        int index = listUIItems.IndexOf(uI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    {
        gameObject.SetActive(true); //activates the inventory
        ResetSelection();
    }

    private void ResetSelection()
    {
        _itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach (InventoryItemUI itemUI in listUIItems) 
        { 
            itemUI.Deselect();
        }
    }

    public void Hide() 
    { 
        gameObject.SetActive(false); //hides the inventory
    }
}
