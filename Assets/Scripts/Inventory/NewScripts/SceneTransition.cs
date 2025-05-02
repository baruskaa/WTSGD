using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public Vector3 newMinPos;
    public Vector3 newMaxPos;

    public Transform transitionPoint;

    private CameraControl control;

    // Start is called before the first frame update
    void Start() {
        control = FindAnyObjectByType<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { 
            control.minCameraPos = newMinPos;
            control.maxCameraPos = newMaxPos;

            other.gameObject.transform.position = transitionPoint.position;
        }
    }
}
