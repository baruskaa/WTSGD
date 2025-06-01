using UnityEngine;

public class SpellBookChecker : MonoBehaviour
{
    [Header("Player Reference")]
    public PlayerManager playerManager;

    [Header("Objects To Enable If Player Has SpellBook")]
    public GameObject[] objectsToEnable;

    [Header("Objects To Disable If Player Has SpellBook")]
    public GameObject[] objectsToDisable;

    [Header("Check On Start")]
    public bool checkOnStart = true;

    private void Start()
    {
        if (checkOnStart)
        {
            UpdateObjectsBasedOnSpellBook();
        }
    }

    /// <summary>
    /// Call this method to update the objects' active state based on player's spellbook possession.
    /// </summary>
    public void UpdateObjectsBasedOnSpellBook()
    {
        if (playerManager == null)
        {
            Debug.LogWarning("PlayerManager reference is missing in SpellBookChecker.");
            return;
        }

        bool hasSpellBook = playerManager.hasMagicSpellBook;

        // Enable objects if player has spellbook
        foreach (GameObject go in objectsToEnable)
        {
            if (go != null)
                go.SetActive(hasSpellBook);
        }

        // Disable objects if player has spellbook
        foreach (GameObject go in objectsToDisable)
        {
            if (go != null)
                go.SetActive(!hasSpellBook);
        }
    }
}
