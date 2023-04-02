using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    // Static instance of the AudioManager to ensure only one instance exists in the scene
    public static AudioManager instance { get; private set; }
    public static AudioManager GetInstance() {
        return instance;
    }

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource playerSource;
    public AudioMixer audioMixer;

    public List<AudioSource> sfxsourcepool;

    public AudioClip[] bgmList;

    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public AudioSource PlaySfx(AudioClip clip)
    {
        // Very non-performant audio source pooling
        foreach (AudioSource src in  sfxsourcepool) {
            if (!src.isPlaying) {
                src.clip = clip;
                src.Play();
                return src;
            }
        }
        return null;
    }

    public void StopSfx(AudioSource src)
    {
        src.Stop();
        src.clip = null;
        
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

    public void SetBGMVolume(Slider volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume.value) * 20);
    }

    public void SetSFXVolume(Slider volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume.value) * 20);
    }
}
