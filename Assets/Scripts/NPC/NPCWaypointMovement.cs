using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaypointMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] waypoints;
    public float waitTimeAtWaypoint = 1f;

    public Rigidbody2D rb;
    public Animator animator;

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPaused || isWaiting || waypoints.Length == 0) return;

        Vector2 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        float distance = Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distance < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        rb.velocity = Vector2.zero;
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }

    public void PauseMovement()
    {
        isPaused = true;
        rb.velocity = Vector2.zero;
        animator.SetFloat("Speed", 0);
    }

    public void ResumeMovement()
    {
        isPaused = false;
    }
}

