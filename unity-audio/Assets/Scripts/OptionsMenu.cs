using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider BGM_Slider;
    public Slider SFX_Slider;

    public AudioMixer mixer;
    public void Start()
    {
        if (!PlayerPrefs.HasKey("BGM") || !PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetFloat("BGM", 1);
            PlayerPrefs.SetFloat("SFX", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void BGMVolume()
    {
        float volume = BGM_Slider.value == 0 ? -80 : Mathf.Log10(BGM_Slider.value) * 20;
        mixer.SetFloat("bgmVol", volume);
    }

    public void SFXVolume()
    {
        float volume = SFX_Slider.value == 0 ? -80 : Mathf.Log10(SFX_Slider.value) * 20; // If dB is set to 0

        // Custom SFX volumes
        float runVolume = SFX_Slider.value == 0 ? -80f : Mathf.Lerp(-80f, -20, SFX_Slider.value);
        float ambienceVolume = SFX_Slider.value == 0 ? -80f : Mathf.Lerp(-80f, 5, SFX_Slider.value);

        mixer.SetFloat("sfxVol", volume);
        mixer.SetFloat("ambienceVol", ambienceVolume);
        mixer.SetFloat("runningVol", runVolume);
    }

    public void Load()
    {
        BGM_Slider.value = PlayerPrefs.GetFloat("BGM");
        SFX_Slider.value = PlayerPrefs.GetFloat("SFX");
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("BGM", BGM_Slider.value);
        PlayerPrefs.SetFloat("SFX", SFX_Slider.value);
        BGMVolume();
        SFXVolume();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneTracker.lastScene);
    }
}
