using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void Play()
    {
        LoadNextLevel();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
            transition.SetTrigger("Start");


            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);

    }
}
