using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    [SerializeField]
    private Button useItemButton;

    [SerializeField]
    private Button removeButton;

    private void OnEnable()
    {
        useItemButton.onClick.AddListener(OnUseItem);
    }
    private void OnDisable()
    {
        useItemButton.onClick.RemoveListener(OnUseItem);
    }

    public void OnUseItem()
    {
        item.UseItem();
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
