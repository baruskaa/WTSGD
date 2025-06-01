using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOff : MonoBehaviour
{
    [Header("Objects To Disable")]
    public GameObject[] objectsToDisable;

    [Header("One-Time Trigger")]
    public GameObject self;
    public bool disableAfterTrigger = false;
    private bool hasTriggered = false;

    public void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableObjects();
            hasTriggered = true;

            if (disableAfterTrigger)
            {
                self.SetActive(false);
            }
        }
    }
}
