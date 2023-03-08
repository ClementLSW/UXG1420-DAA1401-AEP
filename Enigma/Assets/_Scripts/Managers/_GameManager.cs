using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    public static _GameManager instance { get; set; }
    public static _GameManager GetInstance() {
        return instance;
    }

    public void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public GameObject player, deathMenu;
    public Transform spawn, level1Spawn, alphaSpawn;
    //public Canvas deathMenu;

    // Start is called before the first frame update
    //void Start()
    //{
    //    if (instance == null) {
    //        instance = this;
    //    }
    //    else if (instance != this) {
    //        Destroy(gameObject);
    //    }


    //    DontDestroyOnLoad(gameObject);
    //}

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadAlpha() {
        SceneManager.LoadScene("Alpha");
    }

    public void SwitchState(int state) {
        player.GetComponent<Grab>().DestroyHeldItem();
        if (deathMenu.activeSelf) {
            deathMenu.SetActive(false);
        }
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
        deathMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().isAlive = true;

        if (scene.name == "Level1") {
            if(spawn is null) spawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = spawn.transform.position;
        }else if (scene.name == "Alpha") {
            alphaSpawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = alphaSpawn.position;
        }
    }

    public void Death(int deathType) {
        Debug.Log("Died");
        player.GetComponent<Player>().isAlive = false;
        deathMenu.SetActive(true);
        deathMenu.GetComponent<DeathManager>().renderDeathSprite(deathType);
        //switch (deathType) {
        //    case 0:
        //        // Spikey death
        //        Debug.Log("Spikey Death");
        //        break;
        //    case 1:
        //        // Falling death
        //        break;
        //    case 2:
        //        Debug.Log("Crushed By Boulder");
        //        break;
        //    default:
        //        Debug.Log("Something Went Wrong");
        //        break;
        //}
    }
}