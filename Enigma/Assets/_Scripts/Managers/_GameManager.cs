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
    public static bool isPaused { get; private set; }

    public void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            isPaused = false;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            togglePause();
        }
    }

    public GameObject player, deathMenu, mainMenu, pauseMenu;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void togglePause() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log(isPaused);
    }


    public void SwitchState(int state) {
        if(player) player.GetComponent<Grab>().DestroyHeldItem();
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

        if(scene.name == "Tutorial") StartCoroutine(CutsceneManager.instance.PlayCutscene(0));
        if(scene.name == "Level 1")  StartCoroutine(CutsceneManager.instance.PlayCutscene(2));
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
