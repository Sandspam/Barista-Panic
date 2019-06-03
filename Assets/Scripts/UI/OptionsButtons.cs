using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsButtons : MonoBehaviour 
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackToMainMenu ()
    {
        gameObject.transform.parent.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.parent.parent.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
