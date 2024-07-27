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

    void Start()
    {
        if (UpdateList == null)
            UpdateList = new UnityEvent();

        UpdateList.AddListener(PanelInvoke);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeSelf);

            if (panel.activeSelf) 
            {
                UpdateList?.Invoke();
            }
        }
    }

    public void PanelInvoke()
    {
        inventoryManager.ListItems();
        //UpdateList?.Invoke();
    }
}
