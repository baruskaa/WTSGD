using System.Collections;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time = 5;

    [Header("Optional: UI Panel to monitor")]
    public GameObject instructionsPanel;

    [Header("Scene Load Settings")]
    public LevelLoader levelLoader;
    public int sceneIndexToLoad = 1;

    private int tweenId;
    private bool isPaused = false;

    void Start()
    {
        AnimateBar();
    }

    void Update()
    {
        if (instructionsPanel != null)
        {
            if (instructionsPanel.activeSelf && !isPaused)
            {
                LeanTween.pause(tweenId);
                isPaused = true;
            }
            else if (!instructionsPanel.activeSelf && isPaused)
            {
                LeanTween.resume(tweenId);
                isPaused = false;
            }
        }
    }

    public void AnimateBar()
    {
        bar.transform.localScale = new Vector3(1f, bar.transform.localScale.y, bar.transform.localScale.z);
        tweenId = LeanTween.scaleX(bar, 0, time).setOnComplete(OnBarFinished).uniqueId;
    }

    private void OnBarFinished()
    {
        Debug.Log("Bar scale reached 0 — time's up!");
        if (levelLoader != null)
        {
            levelLoader.LoadLevelByIndex(sceneIndexToLoad);
        }
        else
        {
            Debug.LogWarning("LevelLoader not assigned.");
        }
    }
}
