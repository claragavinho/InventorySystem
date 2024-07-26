using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField]
    private Image _itemImg;

    [SerializeField]
    private TMP_Text _quantityTxt;

    [SerializeField]
    private Image _borderImg;

    public event Action<InventoryItemUI> OnItemClicked, OnItemUsed, OnItemBeginDrag, OnItemEndDrag, OnRightMouseClick;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        this._itemImg.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect() 
    { 
        _borderImg.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        this._itemImg.gameObject.SetActive(true);
        this._itemImg.sprite = sprite;
        this._quantityTxt.text = quantity + "";
        this.empty = false;
    }
    public void Select()
    {
        _borderImg.enabled = true;
    }
    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this); //item begins being used
    }
    public void OnDrop()
    {
        OnItemUsed?.Invoke(this); //when the item was used, remove it from inventory
    }
    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this); //resets the items if theyre dragged out of bounds
    }
    public void OnPointerClick(BaseEventData data) //allows the player to click on the inventory
    {
        if (empty)
            return;

        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right) //checks if its the right button
        {
            OnRightMouseClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }    
}
