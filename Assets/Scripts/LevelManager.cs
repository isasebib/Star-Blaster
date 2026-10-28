using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        ScoreKeeper.score = 0;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOver(float delay)
    {
        StartCoroutine(WaitAndLoad(delay));
    }

    IEnumerator WaitAndLoad(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(2);   
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
