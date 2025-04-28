using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItemTwo : ScriptableObject
{

    
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use()
    {
        Debug.Log("Using Item");
        thisEvent.Invoke();
    }

    public void Examine()
    {
        Debug.Log("Examining Item");
        thisEvent.Invoke();
    }
}