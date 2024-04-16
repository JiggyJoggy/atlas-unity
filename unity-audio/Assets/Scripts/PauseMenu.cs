using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public AudioMixerSnapshot defaultAudio;
    public AudioMixerSnapshot muffledAudio;

    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (pauseMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            muffledAudio.TransitionTo(0f);
            Timer.instance.StopStopwatch();
            CameraController camScript = FindAnyObjectByType<CameraController>();
            camScript.enabled = false;

            PlayerController playerScript = FindAnyObjectByType<PlayerController>();
            playerScript.enabled = false;
        }
        else if (pauseMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            defaultAudio.TransitionTo(1f);
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
        defaultAudio.TransitionTo(1f);
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
