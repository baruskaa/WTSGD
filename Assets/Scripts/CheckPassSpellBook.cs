using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPassSpellBook : MonoBehaviour
{
    public GameObject mapPiece;
    public GameObject passPanel;
    public GameObject caseTrigger;
    public InputField inputTextField;
    // Start is called before the first frame update
    void Start()
    {
        inputTextField = GetComponent<InputField>();
    }

    public void CheckPassword()
    {
        if (inputTextField != null)
        {

            if (inputTextField.text == "51573")
            {
                mapPiece.SetActive(true);
                passPanel.SetActive(false);
                caseTrigger.SetActive(false);
            }
            else
            {
                inputTextField.text = "";
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
