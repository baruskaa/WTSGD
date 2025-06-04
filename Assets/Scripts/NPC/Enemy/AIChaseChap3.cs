using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIChaseChap3 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float lineOfSight = 5f;
    public Transform[] waypoints;
    public float waitTimeAtWaypoint = 1f;

    [Header("Scene Load Settings")]
    public LevelLoader levelLoader;
    public int sceneIfSisterSaved;
    public int sceneIfSisterNotSaved;

    private Transform player;
    private PlayerManager playerManager;
    private Rigidbody2D rb;
    private Animator animator;

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private bool isChasing = false;
    private bool hasTriggeredGameOver = false;
    private bool stopMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerManager = playerObj.GetComponent<PlayerManager>();
        }
    }

    void Update()
    {
        if (player == null || hasTriggeredGameOver || stopMoving) return;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSight)
        {
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                StopAllCoroutines();
                isWaiting = false;
            }

            if (!isWaiting && waypoints.Length > 0)
            {
                Patrol();
            }
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void Patrol()
    {
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
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggeredGameOver || !other.CompareTag("Player")) return;

        hasTriggeredGameOver = true;
        stopMoving = true;

        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerManager != null)
        {
            playerManager.PlayDeathAnimation();
        }

        if (playerController != null)
        {
            PlayerController.playerControlsEnabled = false;
            playerController.SetMovementLocked(true);
        }

        StartCoroutine(TriggerSceneLoadAfterDelay());
    }

    private IEnumerator TriggerSceneLoadAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Wait for death animation

        if (levelLoader != null && playerManager != null)
        {
            int sceneToLoad = playerManager.hasSavedSister ? sceneIfSisterSaved : sceneIfSisterNotSaved;
            levelLoader.LoadLevelByIndex(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("LevelLoader or PlayerManager not assigned.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
