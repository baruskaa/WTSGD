using UnityEngine;

public class SisterSaveTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerManager playerManager = other.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.hasSavedSister = true;
            Debug.Log("Sister has been saved.");
        }
        else
        {
            Debug.LogWarning("PlayerManager not found on Player.");
        }

    }
}
