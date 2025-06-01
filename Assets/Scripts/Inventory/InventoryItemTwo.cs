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

    public Sprite inspectSprite; // NEW — sprite to show when inspected

    public InspectorManager inspectorManager; 

    public UnityEvent thisEvent;

    public void Inspect()
    {
        if (isInspectable)
        {
            if (inspectorManager == null)
            {
                inspectorManager = GameObject.FindObjectOfType<InspectorManager>();
            }

            if (inspectorManager != null && inspectSprite != null)
            {
                inspectorManager.ShowInspectPanel(inspectSprite);
            }
            else
            {
                Debug.LogWarning("InspectorManager or inspectSprite missing for " + itemName);
            }
        }

        thisEvent.Invoke();
    }
}
