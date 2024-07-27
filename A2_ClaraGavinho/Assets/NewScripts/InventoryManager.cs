using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryItemController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        items.Add(item);
    }
    public void Remove(Item item) 
    { 
        items.Remove(item);
    }
    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject); //Cleans the content before opening
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var name = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var description = obj.transform.Find("ItemDescription").GetComponent<TMP_Text>();
            var icon = obj.transform.Find("ItemSprite").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").gameObject.GetComponent<Button>();
            Debug.Log("Object");

            name.text = item.itemName;
            Debug.Log("Name");
            description.text = item.itemDescription;
            icon.sprite = item.itemIcon;
        }
        SetInventoryItems();
    }
    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < items.Count; i++) 
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
