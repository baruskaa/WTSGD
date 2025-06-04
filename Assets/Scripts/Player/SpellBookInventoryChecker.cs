using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookInventoryChecker : MonoBehaviour
{
    public PlayerInventory playerInventory; // Drag your ScriptableObject here
    public InventoryItemTwo spellBookItem; // Drag the Spell Book item here
    public PlayerManager playerManager; // Drag the Player GameObject here

    void Start()
    {
        if (playerInventory == null || spellBookItem == null || playerManager == null)
        {
            Debug.LogError("SpellBookChecker is missing a reference.");
            return;
        }

        // Check if spell book exists in inventory and player holds at least one
        if (playerInventory.myInventory.Contains(spellBookItem) && spellBookItem.numberHeld > 0)
        {
            playerManager.hasMagicSpellBook = true;
            Debug.Log("Player has the spell book.");
        }
        else
        {
            playerManager.hasMagicSpellBook = false;
            Debug.Log("Player does NOT have the spell book.");
        }
    }
}
