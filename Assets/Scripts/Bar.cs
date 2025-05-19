using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{

    public GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 0, time).setOnComplete(OnBarFinished);
    }

    private void OnBarFinished()
    {
        Debug.Log("Bar scale reached 0 — time's up!");
        // Put your logic here (e.g. fail state, trigger event, etc.)
    }
}
