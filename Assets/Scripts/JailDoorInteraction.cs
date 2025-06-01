using UnityEngine;
using UnityEngine.UI;

public class JailDoorInteraction : MonoBehaviour
{
    [Header("Player Reference")]
    public PlayerManager playerManager;

    [Header("UI")]
    public GameObject interactionPanel;

    public GameObject openButtonGO;
    public Button openButton;
    public Button breakButton;
    public Button leaveButton;

    [Header("Alarm Settings")]
    public GameObject alarmObject;

    [Header("Door States")]
    public GameObject lockedDoor;
    public GameObject openedDoor;

    private bool playerNearby = false;

    [Header("Civilian States")]
    public GameObject civilianIdle;
    public GameObject civilianFollow;

    [Header("Disable After Freed")]
    public GameObject triggerArea;


    [Header("Enable After Freed")]
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    private void Start()
    {
        interactionPanel.SetActive(false);

        if (openedDoor != null)
            openedDoor.SetActive(false);

        // Hook up button listeners
        openButton.onClick.AddListener(OnUnlockPressed);
        breakButton.onClick.AddListener(OnBreakDoorPressed);
        leaveButton.onClick.AddListener(OnLeavePressed);
    }


    public void ShowPanel()
    {
        Debug.Log("PANEL OPENED");
        if (playerManager == null)
        {
            Debug.Log("PlayerManager is null!");
            return;
        }

        Debug.Log($"HasMagicSpellBook: {playerManager.hasMagicSpellBook}");
        Debug.Log($"IsTraumatized: {playerManager.isTraumatized}");

        interactionPanel.SetActive(true);

        // Open button logic
        if (playerManager.hasMagicSpellBook)
        {
            openButton.interactable = true;
            openButtonGO.SetActive(true);
            Debug.Log("Open button enabled");
        }
        else
        {
            openButton.interactable = false;
            openButtonGO.SetActive(false);
            Debug.Log("Open button disabled");
        }

        // Break button logic - only active if player is traumatized
        if (playerManager.isTraumatized)
        {
            breakButton.interactable = true;
            Debug.Log("Break button enabled");
        }
        else
        {
            breakButton.interactable = false;
            Debug.Log("Break button disabled");
        }
    }


    public void UpdateOpenButtonState()
    {
        if (playerManager.hasMagicSpellBook == true)
        {
            openButton.interactable = true;
            Debug.Log("Open button enabled");
        }
        else
        {
            openButton.interactable = false;
            Debug.Log("Open button disabled");
        }
    }

    public void UpdateBreakButtonState()
    {
        if (playerManager == null) return;

        if (playerManager.isTraumatized)
        {
            breakButton.interactable = true;
            Debug.Log("Break button enabled");
        }
        else
        {
            breakButton.interactable = false;
            Debug.Log("Break button disabled");
        }
    }






    public void OnUnlockPressed()
    {
        Debug.Log("Unlocked door silently.");
        interactionPanel.SetActive(false);

        if (openedDoor != null)
            openedDoor.SetActive(true);
        if (lockedDoor != null)
            lockedDoor.SetActive(false);
        if (civilianIdle != null)
            civilianIdle.SetActive(false);
        if(civilianFollow != null)
            civilianFollow.SetActive(true);


        if (triggerArea != null)
            triggerArea.SetActive(false);

        if (door1 != null)
            door1.SetActive(true);

        if (door2 != null)
            door2.SetActive(true);

        if (door3 != null)
            door3.SetActive(true);
    }

    public void OnBreakDoorPressed()
    {
        Debug.Log("Broke the door! Alarm triggered!");
        interactionPanel.SetActive(false);

        if (alarmObject != null)
            alarmObject.SetActive(true);
        if (openedDoor != null)
            openedDoor.SetActive(true);
        if (lockedDoor != null)
            lockedDoor.SetActive(false);
        if (civilianIdle != null)
            civilianIdle.SetActive(false);
        if (civilianFollow != null)
            civilianFollow.SetActive(true);
        if (triggerArea != null)
            triggerArea.SetActive(false);
    }

    public void OnLeavePressed()
    {
        Debug.Log("Player walked away.");
        interactionPanel.SetActive(false);
    }

}
