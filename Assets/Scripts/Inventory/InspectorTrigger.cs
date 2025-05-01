using UnityEngine;

public class InspectorTrigger : MonoBehaviour
{
    public Sprite imageToInspect;
    public InspectorManager inspectorManager;
    public DialogueTrigger dialogueTrigger;

    private bool hasBeenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenTriggered && collision.CompareTag("Player"))
        {
            hasBeenTriggered = true;

            if (inspectorManager != null && imageToInspect != null)
            {
                inspectorManager.onInspectClosed += TriggerDialogueAfterInspect;
                inspectorManager.ShowInspectPanel(imageToInspect);
            }
            else
            {
                // if inspectorManager or image is missing, just start dialogue
                TriggerDialogueAfterInspect();
            }
        }
    }

    private void TriggerDialogueAfterInspect()
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
