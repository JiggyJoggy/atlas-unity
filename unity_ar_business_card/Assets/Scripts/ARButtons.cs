using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARButtons : MonoBehaviour
{

    public Canvas ARCanvas;
    public Animator OpenAnimation;

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
        OpenAnimation.SetBool("ImageAnime", false);
        ARCanvas.enabled = false;
    }

    public void FoundImage()
    {
        OpenAnimation.SetBool("ImageAnime", true);
        ARCanvas.enabled = true;
    }
}
