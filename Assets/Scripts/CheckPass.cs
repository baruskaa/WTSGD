using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPass : MonoBehaviour
{
    public GameObject mapPiece;
    public GameObject passPanel;
    public GameObject caseTrigger;
    private InputField inputTextField;
    // Start is called before the first frame update
    void Start()
    {
        inputTextField = GetComponent<InputField>();
    }

    public void CheckPassword()
    {
        if (inputTextField != null)
        {

            if (inputTextField.text == "37515")
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
