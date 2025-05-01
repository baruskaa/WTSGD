using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int keyCount;
    public GameObject notify;
    // Start is called before the first frame update
    public void PickupKey()
    {
        keyCount++;
        Debug.Log("key obtained");
    }

    public void UseKey()
    {
        keyCount--;
        Debug.Log("key used");
    }

    public void NotifyPlayer()
    {
        notify.SetActive(true);
    }

    public void DenotifyPlayer()
    {
        notify.SetActive(false);
    }
}
