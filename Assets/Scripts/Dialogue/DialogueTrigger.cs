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
    [Header("DIALOGUE SETTINGS")]
    public Dialogue dialogue;
    public bool disableAfterDialogue;
    public bool isDialogueOnInteract;
    public bool isDisableAlert;
    public GameObject Alert;

    [Header("DIALOGUE TO QUEST")]
    public bool startQuestAfterDialogue;
    public int questNumberToStart;

    [Header("MOVING NPC SETTINGS")]
    public bool isMovingNPC;
    public NPCWaypointMovement npcMovement;

    [Header("ENEMY SETTINGS")]
    public bool activateEnemyAI;
    public GameObject enemyObject; // Assign enemy GameObject here
    public MonoBehaviour enemyAIScript; // Assign the script like EnemyAI.cs

    [Header("POST-DIALOGUE OBJECT TOGGLES")]
    public bool useObjectToggles;
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;

    public void TriggerDialogue()
    {
        if (isMovingNPC && npcMovement != null)
        {
            npcMovement.PauseMovement();
        }

        DialogueManager.Instance.StartDialogue(dialogue, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDialogueOnInteract && collision.CompareTag("Player"))
        {
            if (isDisableAlert && Alert != null)
            {
                Alert.SetActive(false);
            }
            TriggerDialogue();
        }
    }

    public void TriggerDialogueInteract()
    {
        if (isDialogueOnInteract)
        {
            TriggerDialogue();
        }
    }

    public void OnDialogueComplete()
    {
        if (activateEnemyAI && enemyAIScript != null)
        {
            enemyAIScript.enabled = true;

            if (enemyObject != null)
            {
                BoxCollider2D[] colliders = enemyObject.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in colliders)
                {
                    if (col.isTrigger)
                    {
                        col.enabled = true;
                    }
                }
            }
        }

        if (useObjectToggles)
        {
            foreach (GameObject go in objectsToEnable)
            {
                if (go != null) go.SetActive(true);
            }

            foreach (GameObject go in objectsToDisable)
            {
                if (go != null) go.SetActive(false);
            }
        }

        if (isMovingNPC && npcMovement != null)
        {
            npcMovement.ResumeMovement();
        }

        if (disableAfterDialogue)
        {
            gameObject.SetActive(false);
        }
    }
}
