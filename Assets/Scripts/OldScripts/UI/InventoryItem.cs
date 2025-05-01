using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImg;

    [SerializeField]
    private Image borderImg;

    [SerializeField]
    private TMP_Text quantityTxt;

    public event Action<InventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        itemImg.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect()
    {
        borderImg.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        itemImg.gameObject.SetActive(true);
        itemImg.sprite = sprite;
        quantityTxt.text = quantity + "";
        empty = false;
    }

    public void Select()
    {
        borderImg.enabled = true;
    }

    public void OnBeginDrag()
    {
        if ((empty)) return;
        OnItemBeginDrag?.Invoke(this);
        
    }

    public void OnDrop()
    {
       OnItemDroppedOn?.Invoke(this);   

    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);

    }

    public void OnPointerClick(BaseEventData data)
    {

        if (empty)
            return;
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
