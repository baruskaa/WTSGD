using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject currentTeleporter;
    /*private Button button;*/
    public Animator transition;
    public float transitionTime = 0.3f;

    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        /*button.onClick.AddListener(() => {
            Debug.Log("Button clicked");
            StartCoroutine(Teleport());
        });*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;

            if (playerManager != null)
            {
                playerManager.NotifyPlayer();
            }

            /*button.interactable = true;*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter") && collision.gameObject == currentTeleporter)
        {
            currentTeleporter = null;

            Teleporter teleporterComponent = collision.GetComponent<Teleporter>();
            if (playerManager != null && teleporterComponent != null && teleporterComponent.callDenotifyOnExit)
            {
                playerManager.DenotifyPlayer();
            }

            /* button.interactable = false;*/
        }
    }


    private IEnumerator Teleport()
    {
        if (currentTeleporter != null)
        {
            Debug.Log("teleport");

            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

            yield return new WaitForSeconds(transitionTime);

            transition.SetTrigger("End");
        }
    }

    public void StartTeleport()
    {
        StartCoroutine(Teleport());
    }
}
