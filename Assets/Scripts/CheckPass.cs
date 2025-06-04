using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Needed for TextMeshProUGUI

public class CheckPass : MonoBehaviour
{
    public GameObject mapPiece;
    public GameObject passPanel;
    public GameObject caseTrigger;

    public GameObject spellbook;
    public GameObject passPanelSpell;
    public GameObject caseTriggerSpell;

    public GameObject exitTrigger;
    public GameObject oldexitTrigger;

    public bool isReversed;               // New boolean to control reversed state
    public GameObject textTitle;          // GameObject containing the TextMeshProUGUI

    private InputField inputTextField;

    void Start()
    {
        inputTextField = GetComponent<InputField>();

        if (isReversed && textTitle != null)
        {
            TextMeshProUGUI tmpText = textTitle.GetComponent<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.text = "Retne Edoc";
            }
        }
    }

    public void SetReversedTrue()
    {
        isReversed = true;
        UpdateReversedText();
    }

    private void UpdateReversedText()
    {
        if (textTitle != null)
        {
            Text tmpText = textTitle.GetComponent<Text>();
            if (tmpText != null)
            {
                tmpText.text = "Retne Edoc";
            }
        }
    }

    public void CheckPassword()
    {
        if (inputTextField != null)
        {
            if (inputTextField.text == "37515")
            {
                if (mapPiece != null) mapPiece.SetActive(true);

                passPanel.SetActive(false);
                caseTrigger.SetActive(false);
                oldexitTrigger.SetActive(false);
                exitTrigger.SetActive(true);
            }
            else if (inputTextField.text == "51573")
            {
                if (spellbook != null) spellbook.SetActive(true);

                passPanelSpell.SetActive(false);
                caseTriggerSpell.SetActive(false);
                oldexitTrigger.SetActive(false);
            }
            else
            {
                inputTextField.text = "";
            }
        }
    }

    void Update()
    {

    }
}
