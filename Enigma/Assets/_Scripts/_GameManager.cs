using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    public static _GameManager instance;
    public GameObject player;
    public Transform level1Spawn;

    // Start is called before the first frame update
    void Start()
    {
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

    public void SwitchState(int state) {
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
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);

        if (scene.name == "Tutorial") {
            player = GameObject.FindWithTag("Player");
        }else if(scene.name == "Level1") {
            level1Spawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = level1Spawn.transform.position;
        }
    }

    void Death(int deathType) {
        switch (deathType) {
            case 0:
                // Spikey death
                Debug.Log("Spikey Death");
                break;
            case 1:
                // Falling death
                break;
        }

        SwitchState(2);
    }
}
