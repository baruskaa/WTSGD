using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    // Start is called before the first frame update
    public void OpenDoor(GameObject gameObj)
    {

        if (!isOpen) 
        {
            PlayerManager manager = gameObj.GetComponent<PlayerManager>();

            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();
                }
            }

        }
    }
}
