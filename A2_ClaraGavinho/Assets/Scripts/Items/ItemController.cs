using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item newItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PickUp();
            Destroy(this.gameObject);
        }
    }

    void PickUp()
    {
        InventoryManager.Instance.Add(newItem);
    }
}
