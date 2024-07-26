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

    public Sprite sprite;
    public int quantity;
    public string title, description;

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

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemUsed += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(InventoryItemUI uI)
    {
        
    }

    private void HandleEndDrag(InventoryItemUI uI)
    {
        
    }

    private void HandleSwap(InventoryItemUI uI)
    {
        
    }

    private void HandleBeginDrag(InventoryItemUI uI)
    {
        
    }

    private void HandleItemSelection(InventoryItemUI uI)
    {
        _itemDescription.SetDescription(sprite, title, description);
    }

    public void Show()
    {
        gameObject.SetActive(true); //activates the inventory
        _itemDescription.ResetDescription();

        listUIItems[0].SetData(sprite, quantity);
    }
    public void Hide() 
    { 
        gameObject.SetActive(false); //hides the inventory
    }
}
