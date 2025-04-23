using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject currentTeleporter;
    public Button button;
    public Animator transition;
    public float transitionTime = 0.3f;

    void Start()
    {
        button.onClick.AddListener(() => StartCoroutine(Teleport()));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    private IEnumerator Teleport()
    {
        if (currentTeleporter != null)
        {
            transition.SetTrigger("Start");


            yield return new WaitForSeconds(transitionTime);

            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;


            yield return new WaitForSeconds(transitionTime);
           
            transition.SetTrigger("End");

        }
    }
}
