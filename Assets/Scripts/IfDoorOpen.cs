using UnityEngine;

public class IfDoorOpen : MonoBehaviour
{
    public GameObject door;                 // The door GameObject
    public bool isDoorOpen;                // Boolean to track if the door is open

    public GameObject[] objectsToEnable;   // Objects to enable when the door is open
    public GameObject[] objectsToDisable;  // Objects to disable when the door is open

    void Update()
    {
        if (door != null)
        {
            isDoorOpen = door.activeSelf;

            // Enable or disable objects based on the door state
            if (isDoorOpen)
            {
                SetActiveForArray(objectsToEnable, true);
                SetActiveForArray(objectsToDisable, false);
            }
            else
            {
                SetActiveForArray(objectsToEnable, false);
                SetActiveForArray(objectsToDisable, true);
            }
        }
    }

    // Helper function to set active state for array of GameObjects
    void SetActiveForArray(GameObject[] objects, bool state)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(state);
            }
        }
    }
}
