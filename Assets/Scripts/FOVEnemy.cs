using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVEnemy : MonoBehaviour
{

    public float fovAngle = 90f;
    public Transform fovPoint;
    public float range = 8f;

    public Transform target;


    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
        RaycastHit2D r = Physics2D.Raycast(fovPoint.position, dir, range);

        if (angle < fovAngle / 2)
        {
            if (r.collider != null && r.collider.CompareTag("Player"))
            {
                // player seen
                print("Seen");
                Debug.DrawRay(fovPoint.position, dir, Color.red);
            }
            else
            {
                // player not seen 
                print("Not Seen");
            }
        }

    }
}
