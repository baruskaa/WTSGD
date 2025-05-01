using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOff : MonoBehaviour
{
    [Header("Object To Disable")]
    public GameObject GameObject;

    public void DisableObject()
    {
        GameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.SetActive(false);

        }
    }
}
