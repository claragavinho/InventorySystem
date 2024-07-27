using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemValue;
    public ItemType itemType;

    public enum ItemType
    {
        Potion,
        Key
    }
}
