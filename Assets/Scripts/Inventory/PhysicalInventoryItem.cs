using System.Collections;
using UnityEngine;

public class PhysicalInventoryQuestItem : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItemTwo thisItem;

    [Header("Quest Settings")]
    public int questNumber;
    public string itemName;
    private QuestManager theQM;

    private void Start()
    {
        theQM = FindAnyObjectByType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemToInventory();
            UpdateQuest();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }

    void UpdateQuest()
    {
        if (theQM != null && !theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            theQM.itemCollected = itemName;
        }
    }
}
