using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject Timer;
    public GameObject MainCam;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());
    }

    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2);
        Player.GetComponent<PlayerController>().enabled = true;
        MainCam.SetActive(true);
        Timer.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
