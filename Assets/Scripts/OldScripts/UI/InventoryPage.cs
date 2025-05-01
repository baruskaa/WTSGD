using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    public Animator animator;

    List<InventoryItem> listOfItems = new List<InventoryItem>();

    public Transform GetContentPanel()
    {
        return contentPanel;
    }

    public void InitializeInventoryUI(int inventorySize, Transform contentPanel)
    {
        for(int i = 0; i< inventorySize; i++)
        {
            InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.parent = contentPanel;
            listOfItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;

        }
    }

    private void HandleShowItemActions(InventoryItem obj)
    {

    }

    private void HandleEndDrag(InventoryItem obj)
    {

    }

    private void HandleSwap(InventoryItem obj)
    {

    }

    private void HandleBeginDrag(InventoryItem obj)
    {

    }

    private void HandleItemSelection(InventoryItem obj)
    {
        Debug.Log(obj.name);
    }

    public void Show()
    {
        animator.Play("show");
    }

    public void Hide()
    {
        gameObject.SetActive(true);
        animator.Play("hide");
        
    }
}
