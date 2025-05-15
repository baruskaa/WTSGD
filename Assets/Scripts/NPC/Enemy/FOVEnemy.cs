using UnityEngine;

public class EnemyAIWithFOV : MonoBehaviour
{
    [Header("Chase Settings")]
    public Transform player;
    public float speed = 2f;
    public float sightRange = 8f;

    [Header("Field of View")]
    public float fovAngle = 90f;
    public float fovRange = 8f;
    public Transform fovPoint;

    private Vector2 lastMoveDirection = Vector2.down;
    private bool isChasing = false;

    private void Update()
    {
        if (IsPlayerInView())
        {
            isChasing = true;
            Vector2 direction = (player.position - transform.position).normalized;
            lastMoveDirection = direction;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            isChasing = false;
        }

        // Rotate sprite and fovPoint to face the direction
        Vector3 lookDir = isChasing ? (Vector3)lastMoveDirection : (Vector3)lastMoveDirection;
        if (lookDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            if (fovPoint != null)
                fovPoint.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }

    private bool IsPlayerInView()
    {
        Vector2 toPlayer = (player.position - fovPoint.position).normalized;
        float angle = Vector2.Angle(fovPoint.up, toPlayer); // up is forward for Transform in Unity 2D

        if (angle < fovAngle / 2)
        {
            float distance = Vector2.Distance(player.position, fovPoint.position);
            if (distance <= fovRange)
            {
                RaycastHit2D hit = Physics2D.Raycast(fovPoint.position, toPlayer, fovRange);
                if (hit.collider != null && hit.collider.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
