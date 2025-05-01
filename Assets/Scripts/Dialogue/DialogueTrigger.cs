using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool disableAfterDialogue;
    public bool isDialogueOnInteract;
    public GameObject objectToReset;
    public bool isDisableAlert;
    public GameObject Alert;

    public bool startQuestAfterDialogue;
    public int questNumberToStart;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue, this);
    }


private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDialogueOnInteract) {

            if (collision.tag == "Player")
            {
                if (isDisableAlert)
                {
                    Alert.SetActive(false);
                }
                TriggerDialogue();

            }
        }
    }

    public void TriggerDialogueInteract()
    {
        if(isDialogueOnInteract) {

              TriggerDialogue();
            
        }
    }
}