using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AudioManager;

public class _GameManager : MonoBehaviour
{
    public static _GameManager instance;
    public GameObject player;
    public Transform level1Spawn, alphaSpawn, tutorialSpawn;
    private AudioManager audioManager;
    [SerializeField] private AudioClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        
            
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadAlpha() {
        SceneManager.LoadScene("Alpha");
    }

    public void SwitchState(int state) {
        player.GetComponent<Grab>().DestroyHeldItem();
        switch (state) {
            case 0:
                SceneManager.LoadScene("MainMenu");
                break;
            case 1:
                SceneManager.LoadScene("Tutorial");
                break;
            case 2:
                SceneManager.LoadScene("Level1");
                break;
            case 3:
                SceneManager.LoadScene("Level2");
                break;
            case 4:
                SceneManager.LoadScene("Level3");
                break;
            case 5:
                SceneManager.LoadScene("Secret");
                break;
            case 6:
                SceneManager.LoadScene("End");
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);

        if (scene.name == "Tutorial") {
            player = GameObject.FindWithTag("Player");
            tutorialSpawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = tutorialSpawn.transform.position;
        }
        else if(scene.name == "Level1") {
            level1Spawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = level1Spawn.transform.position;
        }else if (scene.name == "Alpha") {
            player = GameObject.FindWithTag("Player");
            alphaSpawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = alphaSpawn.position;
        }
    }

    public void Death(int deathType) {
    audioManager.PlayPlayerSfx(deathClip);
    switch (deathType) {
            case 0:
                // Spikey death
                Debug.Log("Spikey Death");
                break;
            case 1:
                // Falling death
                break;
        }

        //SwitchState(2);
    }
}
