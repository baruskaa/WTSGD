using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    [Header("Chest State")]
    public bool isOpen = false;

    [Header("Item to Drop When Opened")]
    public GameObject itemToActivate;
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest opened!");

            if (itemToActivate != null)
            {
                itemToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No item assigned to drop from chest.");
            }
        }
    }
}
