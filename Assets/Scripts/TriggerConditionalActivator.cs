using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConditionalActivator : MonoBehaviour
{
    [Header("Check if these are inactive")]
    public GameObject[] checkActive;

    [Header("Set these active if corresponding above is inactive")]
    public GameObject[] setActiveTrue;

    [Header("Check if these are active")]
    public GameObject[] checkActiveTrue;

    [Header("Set these inactive if corresponding above is active")]
    public GameObject[] setActiveFalse;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // Enable objects based on inactive checks
        for (int i = 0; i < Mathf.Min(checkActive.Length, setActiveTrue.Length); i++)
        {
            if (checkActive[i] != null && setActiveTrue[i] != null && !checkActive[i].activeSelf)
            {
                setActiveTrue[i].SetActive(true);
            }
        }

        // Disable objects based on active checks
        for (int i = 0; i < Mathf.Min(checkActiveTrue.Length, setActiveFalse.Length); i++)
        {
            if (checkActiveTrue[i] != null && setActiveFalse[i] != null && checkActiveTrue[i].activeSelf)
            {
                setActiveFalse[i].SetActive(false);
            }
        }
    }
}
