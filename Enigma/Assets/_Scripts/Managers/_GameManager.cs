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
    public GameObject player, deathMenu, mainMenu;
    public Transform spawn, level1Spawn, level2Spawn, level3Spawn, alphaSpawn;
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
        if(player) player.GetComponent<Grab>().DestroyHeldItem();
        
        
        //if(state != 0) {
        //    mainMenu.SetActive(false);
        //}
        //else {
        //    mainMenu.SetActive(true);
        //}
        switch (state) {
            case 0:
                SceneManager.LoadScene("Main Menu");
                break;
            case 1:
                SceneManager.LoadScene("Tutorial");
                break;
            case 2:
                SceneManager.LoadScene("Level 1");
                break;
            case 3:
                SceneManager.LoadScene("Level 2");
                break;
            case 4:
                SceneManager.LoadScene("Level 3");
                break;
            case 5:
                SceneManager.LoadScene("Secret");
                break;
            case 6:
                SceneManager.LoadScene("End");
                break;
            case 7:
                SceneManager.LoadScene("Alpha");
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);
        if (deathMenu.activeSelf) {
            deathMenu.SetActive(false);
        }
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().isAlive = true;

        if (scene.name == "Level 1") {
            if (level1Spawn is null) {
                level1Spawn = GameObject.FindWithTag("Respawn").transform;
            }
            player.transform.position = level1Spawn.transform.position;
        }
        else if (scene.name == "Level 2") {
            if (level2Spawn is null) {
                level2Spawn = GameObject.FindWithTag("Respawn").transform;
            }
            player.transform.position = level2Spawn.transform.position;
        }
        else if (scene.name == "Level 3") {
            if (level3Spawn is null) {
                level3Spawn = GameObject.FindWithTag("Respawn").transform;
            }
            player.transform.position = level3Spawn.transform.position;
        }
        else if (scene.name == "Alpha") {
            alphaSpawn = GameObject.FindWithTag("Respawn").transform;
            player.transform.position = alphaSpawn.position;
        }
    }

    public void Death(int deathType) {
        Debug.Log("Died");
        player.GetComponent<Player>().isAlive = false;
        deathMenu.SetActive(true);
        deathMenu.GetComponent<DeathManager>().renderDeathSprite(deathType);
        player.GetComponent<Grab>().DestroyHeldItem();
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
