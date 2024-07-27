using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject, IUsable
{
    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemValue;
    public ItemType itemType;

    public UnityEvent OnUse;
    public void UseItem()
    {
        Debug.Log("Use item");
        OnUse?.Invoke();
    }

    public enum ItemType
    {
        Potion,
        Key
    }
}
