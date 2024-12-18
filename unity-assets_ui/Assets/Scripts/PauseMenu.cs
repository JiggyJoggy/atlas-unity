using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (pauseMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Timer.instance.StopStopwatch();
            CameraController camScript = FindAnyObjectByType<CameraController>();
            camScript.enabled = false;

            PlayerController playerScript = FindAnyObjectByType<PlayerController>();
            playerScript.enabled = false;
        }
        else if (pauseMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Timer.instance.StartStopwatch();
            CameraController camScript = FindAnyObjectByType<CameraController>();
            camScript.enabled = true;

            PlayerController playerScript = FindAnyObjectByType<PlayerController>();
            playerScript.enabled = true;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Timer.instance.StartStopwatch();
    }

    public void Restart()
    {
        SceneTracker.lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneTracker.lastScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneTracker.lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Options");
    }
}
