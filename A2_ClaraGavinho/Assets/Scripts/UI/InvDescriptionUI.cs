using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvDescriptionUI : MonoBehaviour
{
    [SerializeField]
    private Image _itemImg;

    [SerializeField]
    private TMP_Text _title;

    [SerializeField]
    private TMP_Text _description;

    public void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this._itemImg.gameObject.SetActive(false);
        this._title.text = "";
        this._description.text = "";
    }
    public void SetDescription(Sprite sprite, string itemName, string itemDescription)
    {
        this._itemImg.gameObject.SetActive(true); //shows the bg
        this._itemImg.sprite = sprite; //shows the sprite
        this._title.text = itemName; //shows the name of the item
        this._description.text = itemDescription; //shows the description
    }
}
