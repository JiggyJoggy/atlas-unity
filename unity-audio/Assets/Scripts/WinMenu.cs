using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneTracker.lastScene = 0;
            SceneManager.LoadScene(SceneTracker.lastScene);
        }
        else
        {
            SceneTracker.lastScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(SceneTracker.lastScene);
        }
    }
}
