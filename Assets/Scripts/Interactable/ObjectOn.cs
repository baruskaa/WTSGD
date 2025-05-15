using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOn : MonoBehaviour
{
    [Header("Object To Enable")]
    public GameObject GameObject;

    public void EnableObject()
    {
        GameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.SetActive(true);

        }
    }
}
