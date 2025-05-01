using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItemTwo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;

    public bool isInspectable = true; 

    public UnityEvent thisEvent;
    /*public InspectorManager inspectorManager;
    public Sprite objectInspectImage;

    public Button inspectbutton;*/

    public void Inspect()
    {
        Debug.Log("Inspecting Item");
        thisEvent.Invoke();
    }
}
