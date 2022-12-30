using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float RestartDelay = 1f;
    public GameObject CompleteLevelUI;
    private bool GameHasEnded = false;

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            StartCoroutine(RestartCoroutine(RestartDelay));
        }
    }

    IEnumerator RestartCoroutine(float RestartDelay)
    {
        yield return new WaitForSeconds(RestartDelay);
        Restart();
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}