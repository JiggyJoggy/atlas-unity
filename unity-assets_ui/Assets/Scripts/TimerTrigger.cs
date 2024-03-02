using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public MonoBehaviour triggerScript;
    private void OnTriggerExit(Collider other)
    {
        if (IsPlayerObject(other.gameObject))
        {
            triggerScript.enabled = true;
        }
    }

    private bool IsPlayerObject(GameObject obj)
    {
        return obj.GetComponent<PlayerController>() != null;
    }
}
