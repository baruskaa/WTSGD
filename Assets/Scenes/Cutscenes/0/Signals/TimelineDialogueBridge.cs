using UnityEngine;
using UnityEngine.Playables;

public class TimelineDialogueBridge : MonoBehaviour
{
    public PlayableDirector director;

    [Tooltip("Assign the GameObject that contains a DialogueTrigger component.")]
    public GameObject dialogueTarget; // Assign the NPC or object with DialogueTrigger

    private DialogueTrigger currentTrigger;
    private bool waitingForDialogue = false;

    private void Start()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.OnDialogueEnded += OnDialogueEnded;
        }
        else
        {
            Debug.LogError("DialogueManager.Instance is null. Ensure it's loaded before TimelineDialogueBridge.");
        }
    }

    public void TriggerDialogueFromTimeline()
    {
        if (dialogueTarget != null)
        {
            currentTrigger = dialogueTarget.GetComponent<DialogueTrigger>();

            if (currentTrigger != null)
            {
                director.Pause();
                waitingForDialogue = true;
                DialogueManager.Instance.isTimelineControllingPlayer = true;
                currentTrigger.TriggerDialogue();

            }
            else
            {
                Debug.LogWarning("DialogueTrigger not found on assigned GameObject.");
            }
        }
    }

    private void OnDialogueEnded()
    {
        if (waitingForDialogue)
        {
            director.Resume();
            waitingForDialogue = false;
        }
    }
    public void SetDialogueTarget(GameObject target)
    {
        dialogueTarget = target;
    }


}
