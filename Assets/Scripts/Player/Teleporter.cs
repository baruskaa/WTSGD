using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public PlayerManager PlayerManager;

    public bool callDenotifyOnExit = true; 

    public Transform GetDestination()
    {
        return destination;
    }
}
