using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rgbd2d;
    public Animator animator;
    public static bool playerControlsEnabled = true;
    Vector3 movements;

    public Joystick movementJoystick;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start() {

        rgbd2d = GetComponent<Rigidbody2D>();

        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update() {
        if (playerControlsEnabled)
        {
            movements.x = (movementJoystick.Direction.x);
            movements.y = (movementJoystick.Direction.y);


            animator.SetFloat("Horizontal", movementJoystick.Direction.x);
            animator.SetFloat("Vertical", movementJoystick.Direction.y);
            animator.SetFloat("Speed", movements.sqrMagnitude);
        }
           
        
      
    }

    private void FixedUpdate(){
        

        if (movementJoystick.Direction.y != 0)
        {
            rgbd2d.velocity = new Vector3(movementJoystick.Direction.x * moveSpeed, movementJoystick.Direction.y * moveSpeed);
        }
        else
        {
            rgbd2d.velocity = Vector3.zero;
        }
    }

}
