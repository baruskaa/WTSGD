using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SirenColorFlasher : MonoBehaviour
{
    [Header("Siren Colors")]
    public Color color1 = Color.red;
    public Color color2 = Color.blue;

    [Header("Flash Settings")]
    [Tooltip("Time in seconds for one full color cycle (color1 -> color2 -> color1)")]
    public float cycleDuration = 1.0f;

    private SpriteRenderer spriteRenderer;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0f;
    }

    void Update()
    {
        if (cycleDuration <= 0f)
        {
            spriteRenderer.color = color1;
            return;
        }

        timer += Time.deltaTime;

        // Calculate progress between 0 and 1 for half cycle (color1 to color2)
        float halfCycle = cycleDuration / 2f;
        float t = timer % cycleDuration;

        if (t < halfCycle)
        {
            // Lerp from color1 to color2
            spriteRenderer.color = Color.Lerp(color1, color2, t / halfCycle);
        }
        else
        {
            // Lerp from color2 back to color1
            spriteRenderer.color = Color.Lerp(color2, color1, (t - halfCycle) / halfCycle);
        }
    }
}
