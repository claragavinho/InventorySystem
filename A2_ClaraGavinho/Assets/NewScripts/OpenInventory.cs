using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenInventory : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;

    [SerializeField]
    InventoryManager inventoryManager;

    UnityEvent UpdateList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void PanelInvoke()
    {
        inventoryManager.ListItems();
        UpdateList?.Invoke();
    }
}
