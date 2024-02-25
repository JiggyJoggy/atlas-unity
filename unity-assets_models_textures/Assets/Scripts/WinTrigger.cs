using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text TimerText;
    public MonoBehaviour triggerScript;
    private void OnTriggerExit(Collider other)
    {
        if (IsPlayerObject(other.gameObject))
        {
            triggerScript.enabled = false;
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
        }
    }

    private bool IsPlayerObject(GameObject obj)
    {
        return obj.GetComponent<PlayerController>() != null;
    }
}
