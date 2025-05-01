using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{

    //[SerializeField]
    //private InventoryPage inventoryUI;
    // public int inventorySize = 10;

    [SerializeField]
    private GameObject inventoryUI;

    private void Start()
    {
        //inventoryUI.InitializeInventoryUI(inventorySize, inventoryUI.GetContentPanel());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle active 
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    public void Show()
    {
        inventoryUI.SetActive(true);
        //animator.Play("show");
    }

    public void Hide()
    {
        inventoryUI.SetActive(false);
        //animator.Play("hide");

    }

}
