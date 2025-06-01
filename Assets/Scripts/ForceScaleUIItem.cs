using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScaleUIItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject uiPanel;


    void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.transform.localScale = Vector3.one;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
