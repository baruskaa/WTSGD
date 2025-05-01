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

    [Header("GameObj To Activate")]
    public bool isGameObjActivateQuest;
    public GameObject gameObjOn;

    [Header("GameObj To Dectivate")]
    public GameObject gameObjOff;
    public GameObject gameObjOff2;

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

            if (isGameObjActivateQuest && gameObjOn != null) {
                gameObjOn.SetActive(true);
                gameObjOff.SetActive(false);
                gameObjOff2.SetActive(false);
            }
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
