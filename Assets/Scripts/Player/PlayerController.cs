using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rgbd2d;
    public Animator animator;
    public static bool playerControlsEnabled = true;
    Vector3 movements;

    //public Joystick movementJoystick;
    public VirtualJoystick joyStick;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start() {

        playerControlsEnabled = true;

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
            // ORIGINAL SCRIPTS
            //movements.x = (movementJoystick.Direction.x);
            //movements.y = (movementJoystick.Direction.y);


            //animator.SetFloat("Horizontal", movementJoystick.Direction.x);
            //animator.SetFloat("Vertical", movementJoystick.Direction.y);
            //animator.SetFloat("Speed", movements.sqrMagnitude);

            movements = Vector3.zero;
            movements.x = joyStick.HorizontalRaw();
            movements.y = joyStick.VerticalRaw();

            if (movements != Vector3.zero)
            {
                animator.SetFloat("Horizontal", movements.x);
                animator.SetFloat("Vertical", movements.y);
                animator.SetFloat("Speed", movements.sqrMagnitude);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
           
        
      
    }

    private void FixedUpdate(){
        /*if (movementJoystick.Direction.y != 0)
        {
            rgbd2d.velocity = new Vector3(movementJoystick.Direction.x * moveSpeed, movementJoystick.Direction.y * moveSpeed);
        }
        else
        {
            rgbd2d.velocity = Vector3.zero;
        }*/
        rgbd2d.MovePosition(transform.position + movements * moveSpeed * Time.fixedDeltaTime);
            //if (!playerControlsEnabled)
            //{
            //    rgbd2d.velocity = Vector2.zero;
            //    return;
            //}

            //if (movementJoystick.Direction.magnitude > 0)
            //{
            //    rgbd2d.velocity = new Vector2(movementJoystick.Direction.x * moveSpeed, movementJoystick.Direction.y * moveSpeed);
            //}
            //else
            //{
            //    rgbd2d.velocity = Vector2.zero;
            //}

    }

    public void SetMovementLocked(bool locked)
    {
        if (locked)
        {
            rgbd2d.velocity = Vector2.zero;
            rgbd2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rgbd2d.constraints = RigidbodyConstraints2D.None;
            rgbd2d.constraints = RigidbodyConstraints2D.FreezeRotation; 
        }
    }


}
