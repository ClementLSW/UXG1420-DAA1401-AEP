using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    // Static instance of the AudioManager to ensure only one instance exists in the scene
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource playerSource;
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

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayPlayerSfx(AudioClip clip)
    {
        playerSource.clip = clip;
        playerSource.Play();
    }

    public void StopSfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Stop();
    }

    public void PlayBGM(AudioClip clip, bool isLoop = true){
        musicSource.clip = clip;
        musicSource.loop = isLoop;
        musicSource.Play();
    }

    public void StopBGM(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Stop();
    }

    // public void SetMasterVolume(float volume)
    // {
    //     audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    // }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
