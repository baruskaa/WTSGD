using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    [SerializeField] private GameObject inventoryUI;
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    //[SerializeField] private GameObject examineButton;
    public InventoryItemTwo currentItem;
    public InspectorManager inspectorManager;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
           // examineButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
          //  examineButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp =
                    Instantiate(blankInventorySlot,
                    inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    private void Start()
    {
        Hide();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        Debug.Log("made inventory");
        SetTextAndButton("", false);
    }

    public void SetupDescriptionAndButton(string newDescriptionString,
        bool isButtonUsable, InventoryItemTwo newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
       // examineButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Transform child = inventoryPanel.transform.GetChild(i);
            // nagugulo ui pag wala ung unang slot
            if (!child.CompareTag("DoNotDestroy"))
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void InspectButtonPressed()
    {
        if (currentItem)
        {
            currentItem.inspectorManager = inspectorManager;
            currentItem.Inspect();
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
