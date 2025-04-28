using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnRun : MonoBehaviour
{

    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        gameObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
