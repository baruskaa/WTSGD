using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepJoystick : MonoBehaviour
{
    public static KeepJoystick instance;
    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


}

    // Update is called once per frame
    void Update()
    {
        
    }
}
