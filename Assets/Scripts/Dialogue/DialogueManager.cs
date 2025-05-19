using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject DialogueBox;

    public PlayerManager playerManager;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    public Animator animator;


    public GameObject interactBtn;
    public GameObject inventBtn;
    public GameObject joystick;
    public VirtualJoystick virtualJoystick;

    private DialogueTrigger currentTrigger;

    public bool isTimelineControllingPlayer = false;


    public event System.Action OnDialogueEnded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger = null)
    {
        currentTrigger = trigger; 

        interactBtn.SetActive(false);
        inventBtn.SetActive(false);
        joystick.SetActive(false);
        DialogueBox.SetActive(true);
        isDialogueActive = true;

        if (!isTimelineControllingPlayer)
        {
            PlayerController.playerControlsEnabled = false;

            PlayerController.instance.rgbd2d.velocity = Vector2.zero;
            PlayerController.instance.animator.SetFloat("Speed", 0);
            PlayerController.instance.animator.SetFloat("Horizontal", 0);
            PlayerController.instance.animator.SetFloat("Vertical", 0);

            PlayerController.instance.SetMovementLocked(true);

            virtualJoystick.ResetAnalog();
        };

        virtualJoystick.ResetAnalog();

        animator.Play("show");
        
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        Debug.Log("continue");
        if (lines.Count == 0)
        {
            Debug.Log("end");
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {

        if (!isTimelineControllingPlayer)
        {
            PlayerController.playerControlsEnabled = true;
            PlayerController.instance.SetMovementLocked(false);
        }
        isTimelineControllingPlayer = false;

        PlayerController.playerControlsEnabled = true;
        animator.Play("hide");
        isDialogueActive = false;
        DialogueBox.SetActive(false);
        interactBtn.SetActive(true);
        inventBtn.SetActive(true);
        joystick.SetActive(true);
        PlayerController.playerControlsEnabled = true;
        PlayerController.instance.SetMovementLocked(false);


        if (currentTrigger != null && currentTrigger.isMovingNPC && currentTrigger.npcMovement != null)
        {
            currentTrigger.npcMovement.ResumeMovement();
        }

        //Start quest if requested
        if (currentTrigger != null && currentTrigger.startQuestAfterDialogue)
        {
            QuestManager questManager = FindAnyObjectByType<QuestManager>();
            if (questManager != null && currentTrigger.questNumberToStart < questManager.quests.Length)
            {
                QuestObject quest = questManager.quests[currentTrigger.questNumberToStart];
                if (quest != null)
                {
                    quest.gameObject.SetActive(true);
                    quest.StartQuest();
                }
            }
        }

        // Add this to activate enemy behavior and disable trigger collider
        if (currentTrigger != null) currentTrigger.OnDialogueComplete();

        DisableDialogue();

        OnDialogueEnded?.Invoke();
    }


    public void DisableDialogue()
    {
        if (currentTrigger != null)
        {
            //if (currentTrigger.objectToReset != null)
            //{
            //    Vector3 pos = currentTrigger.objectToReset.transform.position;
            //    currentTrigger.objectToReset.transform.position = new Vector3(0, 0, pos.z);
            //}

            if (currentTrigger.disableAfterDialogue)
            {
                currentTrigger.gameObject.SetActive(false);
                playerManager.DenotifyPlayer();
            }
        }

        // Stop the player's movement
        PlayerController.instance.rgbd2d.velocity = Vector2.zero;
        PlayerController.instance.animator.SetFloat("Speed", 0);
        PlayerController.instance.animator.SetFloat("Horizontal", 0);
        PlayerController.instance.animator.SetFloat("Vertical", 0);

        currentTrigger = null;
    }


}