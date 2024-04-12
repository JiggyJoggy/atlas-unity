using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneTracker.lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        SceneTracker.lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
