using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOn : MonoBehaviour
{
    [Header("Objects To Enable")]
    public GameObject[] objectsToEnable;


    [Header("One-Time Trigger")]
    public GameObject self;
    public bool disableAfterTrigger = false;
    private bool hasTriggered = false;

    public void EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            EnableObjects();
            hasTriggered = true;

            if (disableAfterTrigger)
            {
                self.SetActive(false);
            }
        }
    }

}