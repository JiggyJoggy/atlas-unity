using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Text TimerText;
    private Stopwatch stopwatch;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
    }

    public Stopwatch GetStopwatch()
    {
        return stopwatch;
    }
    public void StopStopwatch()
    {
        stopwatch.Stop();
    }
    public void StartStopwatch()
    {
        stopwatch.Start();
    }
}
