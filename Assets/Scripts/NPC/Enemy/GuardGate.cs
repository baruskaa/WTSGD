using UnityEngine;
using UnityEngine.UI;

public class GuardGate : MonoBehaviour
{
    [Header("UI")]
    public GameObject optionsPanel;

    [Header("Dialogue Triggers")]
    public GameObject dialogueA; // When player has magic spell book
    public GameObject dialogueB; // When player does NOT have the book
    public Button interactButton;

    private bool playerNearby = false;
    private PlayerManager player;

    private void Start()
    {
        optionsPanel.SetActive(false);
        player = FindObjectOfType<PlayerManager>();

        // Hook button to open panel
        if (interactButton != null)
            interactButton.onClick.AddListener(() => ToggleOptionsPanel(true));
    }


    public void ToggleOptionsPanel(bool isActive)
    {
        optionsPanel.SetActive(isActive);
    }

    public void OnAskForKey()
    {
        ToggleOptionsPanel(false);

        if (player == null) return;

        if (player.hasMagicSpellBook)
        {
            Debug.Log("Hypnotizing guard...");
            if (dialogueA != null)
                dialogueA.GetComponent<DialogueTrigger>()?.TriggerDialogueInteract();
        }
        else
        {
            Debug.Log("Guard gets angry...");
            if (dialogueB != null)
                dialogueB.GetComponent<DialogueTrigger>()?.TriggerDialogueInteract();
        }
    }

    public void OnWalkAway()
    {
        ToggleOptionsPanel(false);
        Debug.Log("Player chose to walk away.");
    }



    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerNearby = true;
    //        player?.NotifyPlayer();
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerNearby = false;
    //        ToggleOptionsPanel(false);
    //        player?.DenotifyPlayer();
    //    }
    //}
}
