using UnityEngine;

public class ChasePlayerNPC : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Movement Settings")]
    public float speed = 3f;
    public float sight = 10f;
    public float minDistance = 2f;

    [Header("Obstacle Avoidance")]
    public string obstacleTag = "Survivor"; // Set the tag of your walls to "Wall"
    public float obstacleAvoidanceDistance = 1.5f;

    private float distance;

    void Update()
    {
        if (player == null) return;

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < sight && distance > minDistance)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // Raycast to check for obstacles directly ahead
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleAvoidanceDistance);

            if (hit.collider != null && hit.collider.CompareTag(obstacleTag))
            {
                // Wall detected: choose a perpendicular direction to avoid
                Vector2 avoidDir = Vector2.Perpendicular(direction);

                // Try left first
                RaycastHit2D sideHit = Physics2D.Raycast(transform.position, avoidDir, 1f);
                if (sideHit.collider != null && sideHit.collider.CompareTag(obstacleTag))
                {
                    avoidDir = -avoidDir; // Try the other side
                }

                direction += avoidDir;
                direction.Normalize();
            }

            Vector2 targetPosition = (Vector2)player.transform.position - direction * minDistance;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
