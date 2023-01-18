using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This script creates an AudioManager object that can play sound effects and music.
/// </summary>

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Static instance of the AudioManager to ensure only one instance exists in the scene
    /// </summary>
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioMixer audioMixer;

    public AudioClip[] bgmList;

    void Awake()
    {
        //Ensure only one instance of AudioManager exists
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Dont destroy this object on scene change
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Play a single sound effect
    /// </summary>
    /// <param name="clip">The AudioClip to play</param>

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    private void PlayBGM(AudioClip clip, bool isLoop = true){
        musicSource.clip = clip;
        musicSource.loop = isLoop;
        musicSource.Play();
    }

    /// <summary>
    /// Set the volume of the master mixer group
    /// </summary>
    /// <param name="volume">The volume level to set (between 0 and 1)</param>
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
