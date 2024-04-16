using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Text TimerText;
    public TMP_Text DupText;
    public MonoBehaviour triggerScript;
    public GameObject WinScreen;
    public GameObject TimerScreen;
    public AudioSource BGMusic;
    public AudioSource VictoryMusic;
    private void OnTriggerExit(Collider other)
    {
        if (IsPlayerObject(other.gameObject))
        {
            Win();
        }
    }

    private bool IsPlayerObject(GameObject obj)
    {
        return obj.GetComponent<PlayerController>() != null;
    }

    public void Win()
    {
        BGMusic.enabled = false;
        VictoryMusic.enabled = true;
        Timer.instance.StopStopwatch();
        DupText.SetText(TimerText.text);
        TimerScreen.SetActive(false);
        WinScreen.SetActive(true);
    }
}
