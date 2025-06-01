using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public CanvasGroup gameOverCanvasGroup; // Add this
    public Animator transition;
    public float transitionTime = 1f;
    public float fadeDuration = 1f; // for UI fade-in

    public void GameOver()
    {
        StartCoroutine(HandleGameOver());
    }

    private IEnumerator HandleGameOver()
    {
        yield return new WaitForSeconds(transitionTime);

        // Enable Game Over UI
        gameOverUI.SetActive(true);
        gameOverCanvasGroup.alpha = 0f;
        gameOverCanvasGroup.interactable = false;
        gameOverCanvasGroup.blocksRaycasts = false;

        // Animate the alpha
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            gameOverCanvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }


        gameOverCanvasGroup.interactable = true;
        gameOverCanvasGroup.blocksRaycasts = true;
    }

    public void RestartLevel(int sceneBuildIndex)
    {
        PlayerController.playerControlsEnabled = true;

        gameOverUI.SetActive(false);
        StartCoroutine(ReloadLevelByIndex(sceneBuildIndex));
    }

    private IEnumerator ReloadLevelByIndex(int sceneBuildIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
