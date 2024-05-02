using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARButtons : MonoBehaviour
{

    public Canvas ARCanvas;

    public void GitHubURL()
    {
        Application.OpenURL("https://github.com/JiggyJoggy");
    }

    public void LinkedInURL()
    {
        Application.OpenURL("https://linkedin.com/in/jaggervw");
    }

    public void GmailURL()
    {
        Application.OpenURL("https://JaggerVanW@gmail.com");
    }

    public void TwitchURL()
    {
        Application.OpenURL("https://twitch.tv/jaggpegg_");
    }

    public void LostImage()
    {
        ARCanvas.enabled = false;
    }

    public void FoundImage()
    {
        ARCanvas.enabled = true;
    }
}
