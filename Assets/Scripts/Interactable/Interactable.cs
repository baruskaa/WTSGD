using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public Button button;
    public UnityEvent interactAction;

    private bool listenerAdded = false;

    public bool triggerDialogueAfterInspect;
    public bool triggerDialogueOnClose;
    public DialogueTrigger dialogueTrigger;
    public InspectorManager inspectorManager;
    public Sprite objectImage;


    void Start()
    {
        button.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }

            if (!listenerAdded)
            {
                button.onClick.AddListener(() => interactAction.Invoke());
                listenerAdded = true;
            }
        }
        else
        {
            if (listenerAdded)
            {
                button.onClick.RemoveAllListeners();
                listenerAdded = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange= true;
            Debug.Log("player in range");
            collision.gameObject.GetComponent<PlayerManager>().NotifyPlayer();
            button.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("player NOT in range");
            collision.gameObject.GetComponent<PlayerManager>().DenotifyPlayer();
            button.interactable = false;
        }
    }

    public void Inspect()
    {
        inspectorManager.ShowInspectPanel( objectImage);

        // Set the callback AFTER panel is closed
        inspectorManager.onInspectClosed = () =>
        {
            if (triggerDialogueAfterInspect && dialogueTrigger != null)
            {
                dialogueTrigger.TriggerDialogue();
            }
        };
    }

}
